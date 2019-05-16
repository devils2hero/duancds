using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EG.Security.JWT.Policy.BankQuestion
{
    public static class BankQuestionPolicy
    {
        public static IServiceCollection AddPolicy(this IServiceCollection obj)
        {
            obj.AddAuthorization(options =>
            {
                options.AddPolicy("AuthAPIBankQuestion", policy => policy.Requirements.Add(new Attributes.AuthRequirement()));
            });

            obj.AddTransient<IAuthorizationHandler, Attributes.JWTAtrribute>();
            return obj;
        }
    }
}
