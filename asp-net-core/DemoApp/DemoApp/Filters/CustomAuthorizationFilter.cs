using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DemoApp.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!IsAuthorized(context.HttpContext.User))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool IsAuthorized(ClaimsPrincipal user)
        {
            // Check if the user is authorized to access the resource
            // Custom authorization logic here

            return user.Identity.IsAuthenticated && user.IsInRole("Admin");
        }
    }
}
