using sRecipe.WebUI.Infrastructures.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.App_Start
{
    public class ControllerConfig
    {
        public static void SetControllerFactory(ControllerBuilder builder)
        {
            builder.SetControllerFactory(typeof(ThemeControllerFactory));
        }
    }
}