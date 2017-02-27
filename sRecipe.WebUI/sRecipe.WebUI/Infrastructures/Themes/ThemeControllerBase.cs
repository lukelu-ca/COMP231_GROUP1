using Ninject;
using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using sRecipe.WebUI.Infrastructures.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sRecipe.WebUI.Infrastructures.Themes
{
    public abstract class ThemeControllerBase : Controller
    {
        protected virtual new sRecipePrincipal User
        {
            get;
            private set;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.IsAuthenticated)
            {
                User = requestContext.HttpContext.User as sRecipePrincipal;
                base.ViewBag.ColorTheme = User.Profile.ColorTheme;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ColorTheme"]))
                {
                    base.ViewBag.ColorTheme = ConfigurationManager.AppSettings["ColorTheme"];
                }
                else
                {
                    base.ViewBag.ColorTheme = "Default";
                }
            }
            base.Initialize(requestContext);
        }
    }
}