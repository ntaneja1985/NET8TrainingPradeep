using Asp.Versioning;
using Asp.Versioning.Conventions;
using BusinessLayer;
using BusinessLayer.Abstraction;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

//builder.Services.AddApiVersioning(options => 
//{   options.AssumeDefaultVersionWhenUnspecified = true; 
//    options.DefaultApiVersion = new ApiVersion(1, 0);
//    options.ReportApiVersions = true; options.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader("api-version"), new HeaderApiVersionReader("x-api-version"), new MediaTypeApiVersionReader("v")); 
//});

builder.Services.AddApiVersioning(op =>
{
    op.DefaultApiVersion = new ApiVersion(1.0);
    op.AssumeDefaultVersionWhenUnspecified = true;
})
.AddMvc(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention());
    //options.Conventions.Controller<WebAPI.V1.Controllers.ProductAPIController>().HasApiVersion(1.0);
    //options.Conventions.Controller<WebAPI.V2.Controllers.ProductAPIV2Controller>().HasApiVersion(2.0);
});

//builder.Services.AddVersionedApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; options.SubstituteApiVersionInUrl = true; });

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddCors(config =>
{
    config.AddPolicy("mypolicy", opt =>
    {
        opt.AllowAnyHeader();
        opt.WithOrigins("https://localhost:7066");
        opt.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Responsible for validating the JWT 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer( config =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
    
   
});

app.MapGet("/getname/{id}", (string id) => $"Hello {id}");

app.MapGet("/list", (IProductBL productBL) => 
GetAllProducts(productBL)).Accepts<List<ProductViewModel>>("application/json");

app.UseHttpsRedirection();
app.UseCors("mypolicy");
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();

IResult GetAllProducts(IProductBL productBL)
{
    return Results.Ok(productBL.GetAllProducts());
}
