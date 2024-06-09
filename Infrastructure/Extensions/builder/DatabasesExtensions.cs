using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Extensions.builder
{
    public static class DatabasesExtensions
    {

        
        public static IServiceCollection AddAndMigrateDatabases(this IServiceCollection services, IConfiguration config)
        {
            try
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    var connectionString = config.GetConnectionString("DefaultConnection");
                    
                    if (connectionString != null)
                        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("RCHU"));
                });
                
                return services;
            }
            catch (Exception)
            {
                // Log or handle the exception
                return services;
            }

        }
    }
}
