using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.builder
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection Authentication(this IServiceCollection services, IConfiguration config)
        {

            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "WEBAPPAuth";
            })
                .AddCookie("WEBAPPAuth" , "WEBAPPAuth" , config =>
                {
                    config.Cookie.HttpOnly = true;
                    config.Cookie.SameSite = SameSiteMode.Lax;
                    config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                    config.LoginPath = "/Account/Login";
                    config.AccessDeniedPath = "/Account/Error";
                    config.LogoutPath = "/Account/Logout";
                })
                .AddJwtBearer("APIAuth", "APIAuth", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = config["JWTSettings:Audience"],
                        ValidIssuer = config["JWTSettings:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"]))

                    };
                });
            return services;
        }

    }
}
