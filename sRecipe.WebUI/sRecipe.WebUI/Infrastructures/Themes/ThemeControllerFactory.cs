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
           
            string viewTheme=string.Empty;
            string colorTheme = "Default";

            if (requestContext.HttpContext.Request.IsAuthenticated && requestContext.HttpContext.User != null)
            {
                sRecipePrincipal user = requestContext.HttpContext.User as sRecipePrincipal;
                (controller as ThemeControllerBase).User= user;
                viewTheme = user.Profile.ViewTheme;
                colorTheme = user.Profile.ColorTheme;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ViewTheme"]))
                {
                    viewTheme = ConfigurationManager.AppSettings["ViewTheme"];
                }
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ColorTheme"]))
                {
                    colorTheme = ConfigurationManager.AppSettings["ColorTheme"];
                }

            }
            controller.ViewBag.ColorTheme = colorTheme;

            if (!string.IsNullOrWhiteSpace(viewTheme))
            {
                var eng = controller.ViewEngineCollection[0];
                if (eng is ThemeViewEngine)
                {
                    (eng as ThemeViewEngine).SetThemeName(viewTheme);
                }
                else
                {
                    controller.ViewEngineCollection.Insert(0, new ThemeViewEngine(viewTheme));
                }
            }


            return controller;
        }
    }
}