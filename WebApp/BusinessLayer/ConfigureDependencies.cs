using BusinessLayer.Abstraction;
using BusinessLayer.Implementation;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
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
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ICustomerBL, CustomerBL>();

            services.AddScoped<DemoDbContext>();
        }
    }
}
