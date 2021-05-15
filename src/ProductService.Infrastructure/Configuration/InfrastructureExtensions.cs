using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interface;
using ProductService.Infrastructure.Database;
using ProductService.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Configuration
{
    public static class InfrastructureExtensions
    {
        /// <summary>
        /// Adds infrastructure services to the services collection
        /// To be used in startup.cs ConfigureServices method
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddDbContext<ProductContext>(o => o.UseSqlServer(configuration.GetConnectionString("ProductService")));
            
            return services;
        }
    }
}
