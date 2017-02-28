using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    /// <summary>
    /// Filter for Authorized Administrator
    /// Use this attribute on an action of controller which indicates only administrator role
    /// </summary>
    public class AdminAuthAttribute : FilterAttribute, IAuthenticationFilter

    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            if (ident.IsAuthenticated && !string.IsNullOrWhiteSpace(ident.Name) && filterContext.HttpContext.User.IsInRole("Administrator"))
            {
                return;
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                {"controller", "Account"},
                                {"action", "Login"},
                                {"returnUrl", context.HttpContext.Request.RawUrl}
                                });
            }
        }
    }
}