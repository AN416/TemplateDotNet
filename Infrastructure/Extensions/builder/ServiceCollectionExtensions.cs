
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.builder
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ServicesCollection(this IServiceCollection services, IConfiguration config)
        {
          
            services.AppSettings(config);
            services.AddAndMigrateDatabases(config);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddEndpointsApiExplorer();
            services.AddSwagger(config);
            services.Authentication(config);
            services.Interfaces(config);
            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }

    }
}
