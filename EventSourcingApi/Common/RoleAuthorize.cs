using EventSourcing.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventSourcingApi.Common
{
    public class RoleAuthorize(params string[] roles) : AuthorizeAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userManager = (UserManager<User>)context.HttpContext.RequestServices.GetService(typeof(UserManager<User>));
            var user = userManager.FindByEmailAsync(context.HttpContext.User.Identity.Name).Result;
            var userroles = userManager.GetRolesAsync(user).Result;
            if (!userroles.Intersect(roles).Any())
            {
                context.Result = new UnauthorizedResult();

            }
            return;
        }
    }
}
