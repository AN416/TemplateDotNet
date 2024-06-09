using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.builder
{
    public static class AppSettingsExtensions
    {
        public static IServiceCollection AppSettings(this IServiceCollection services, IConfiguration config)
        {


            return services;
        }
    }
}
