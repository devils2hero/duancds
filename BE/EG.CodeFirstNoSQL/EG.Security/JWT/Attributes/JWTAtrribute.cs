using Microsoft.AspNetCore.Authorization;
using EG.Web.Core.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace EG.Security.JWT.Attributes
{
    public class JWTAtrribute : AuthorizationHandler<AuthRequirement>
    {
        private readonly IDistributedCacheLayer _DistributedCacheLayer;
        public JWTAtrribute(IDistributedCacheLayer _DistributedCacheLayer)
        {
            this._DistributedCacheLayer = _DistributedCacheLayer;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
        {
            //var user = Providers.TokenProvider.GetInfoByJWTTokens(context.User);
            //if(user.Count < 1)
            //{
            //    return Task.CompletedTask;
            //}
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
            // Get Token by Context
            var Token = mvcContext.HttpContext.Request.Headers["Authorization"];
            //GetToken In BlackList in Redis Cache
            //var TokenBlackList = _DistributedCacheLayer.GetCache(Token);
            // Check BlackList and UnAuthorize
            //if (TokenBlackList != null && TokenBlackList.Equals(user.Where(c => c.Key.Equals("jti"))?.FirstOrDefault()?.Value))
            //{
            //    return Task.CompletedTask;
            //}
            //if (user.Where(c => c.Key == "SupperUser").FirstOrDefault().Value == "True")
            //{
            //    context.Succeed(requirement);
            //    return Task.CompletedTask;
            //}
            //var ListUrl = user.Where(c => c.Key == "URL").FirstOrDefault().Value.StringToList("|");
            //if (ListUrl.Any(n => n.Equals(mvcContext.HttpContext.Request.Path)))
            //{
            //    context.Succeed(requirement);
            //}
            //else
            //{
            //    context.Fail();
            //}
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
