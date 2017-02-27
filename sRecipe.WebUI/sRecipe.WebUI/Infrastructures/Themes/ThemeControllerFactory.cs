using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using sRecipe.WebUI.Infrastructures.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Themes
{
    public class ThemeControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            Controller controller = base.CreateController(requestContext, controllerName) as Controller;
            string themeName=string.Empty;
            if (requestContext.HttpContext.Request.IsAuthenticated && requestContext.HttpContext.User != null)
            {
                sRecipePrincipal user = requestContext.HttpContext.User as sRecipePrincipal;
                themeName = user.Profile.ViewTheme;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ViewTheme"]))
                {
                    themeName= ConfigurationManager.AppSettings["ViewTheme"];
                }
            }
            if (!string.IsNullOrWhiteSpace(themeName))
            {
                var eng = controller.ViewEngineCollection[0];
                if (eng is ThemeViewEngine)
                {
                    (eng as ThemeViewEngine).SetThemeName(themeName);
                }
                else
                {
                    controller.ViewEngineCollection.Insert(0, new ThemeViewEngine(themeName));
                }
            }


            return controller;
        }
    }
}