using Microsoft.AspNetCore.Authorization;

namespace EG.Security.JWT.Attributes
{
    public class AuthRequirement : IAuthorizationRequirement
    {
        public AuthRequirement()
        {
        }
    }
}
