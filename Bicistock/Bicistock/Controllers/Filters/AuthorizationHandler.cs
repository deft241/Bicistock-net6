using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bicistock.Controllers.Filters
{
    public class AuthorizationHandler : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int? role = context.HttpContext.Session.GetInt32("Role");
            if (role == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "controller", "Home" },
                    { "action", "Index" }
                    });
            }
        }
    }
}
