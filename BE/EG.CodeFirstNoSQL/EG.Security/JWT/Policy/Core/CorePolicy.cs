using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EG.Security.JWT.Policy.Core
{
    public static class CorePolicy
    {
        public static IServiceCollection AddPolicy(this IServiceCollection obj)
        {
            obj.AddAuthorization(options =>
            {
                options.AddPolicy("AuthAPIChildDevelopSkills", policy => policy.Requirements.Add(new Attributes.AuthRequirement()));
            });

            obj.AddTransient<IAuthorizationHandler, Attributes.JWTAtrribute>();
            return obj;
        }
    }
}
