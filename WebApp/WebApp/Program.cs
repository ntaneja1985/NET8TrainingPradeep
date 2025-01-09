using BusinessLayer;
using BusinessLayer.Abstraction;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Custom;

var builder = WebApplication.CreateBuilder(args);

//var env = Environment.GetEnvironmentVariable("MyEnv");
//if(env == null)
//{
//    throw new Exception("MyEnv configuration is not set");
//}

// Add services to the container.
//builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("MyEnv").ToLower()}.json", optional: false);
builder.Services.AddControllersWithViews();

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(20);
});

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,options =>
{
    options.Cookie.Name = "AuthToken";
    options.LoginPath = new PathString("/account/login");
    options.AccessDeniedPath = new PathString("/account/accessdenied");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUser", policy => policy.RequireRole("User"));
});

var app = builder.Build();

//Middleware starts from here

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();

app.UseJwtMiddleware();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/hello", () =>
{
    return "Hello from me";
}).ShortCircuit();

app.MapShortCircuit(404, "favicon.ico");

app.MapGet("/product/list", (IProductBL productBL) =>
{
    return productBL.GetAllProducts();
});

app.MapGet("/getmyname/{id}", (string id) =>
{
    return "Hello from me" + id;
});

app.Map("/test", mappedMap =>
{
    mappedMap.Use(async (context, next) =>
    {
        Console.WriteLine("Middleware before test");
        await context.Response.WriteAsync("Hello from the test");
        await next();
        Console.WriteLine("Middleware after the test");
    });

    mappedMap.Run(async context =>
    {
        Console.WriteLine("Terminated Middleware");
        await Task.CompletedTask;
    });
});
//app.MapGet("/health", ():IResult =>
//{
//    return Status;
//}).ShortCircuit();

app.Use(async (context, next) =>
{
    Console.WriteLine("a middleware: start");
    await next();
    Console.WriteLine("a middleware: end");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("b middleware: start");
    await next();
    Console.WriteLine("b middleware: end");
});

app.Run();
