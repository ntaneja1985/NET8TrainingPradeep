using BusinessLayer.Abstraction;
using BusinessLayer.Implementation;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories.Abstraction;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            //services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ICustomerBL>(provider =>
            {
                var catRepo = provider.GetRequiredService<ICategoryRepository>();
                return new CustomerBL(catRepo, "test data");
            });

            //services.AddScoped<DemoDbContext>();
            services.AddDbContext<DemoDbContext>(option =>
            {
                string connectionString = configuration.GetConnectionString("conn") ?? "";
                option.UseSqlServer(connectionString);
            });
        }
    }
}
