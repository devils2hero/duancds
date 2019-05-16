using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Security.JWT.Dependency
{
    public static class DependencyJWT
    {
        public static IServiceCollection AddDependencyJWT(this IServiceCollection services,string ValidIssuer, List<string> ValidAudiences, string Key)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = ValidIssuer,
                       ValidAudiences = ValidAudiences,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
                   };
                   options.RequireHttpsMetadata = true;
               });
            return services;
        }
    }
}
