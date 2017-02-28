using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Themes
{
    public class ThemeViewEngine : RazorViewEngine
    {
        public string ViewTheme { get; set; }

        public void SetViewTheme(string value)
        {
            this.ViewTheme = value;
            base.ViewLocationFormats = new[]
           {
                "~/Views/Themes/" + ViewTheme + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + ViewTheme + "/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            base.PartialViewLocationFormats = new[]
           {
                "~/Views/Themes/" + ViewTheme + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + ViewTheme + "/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
               };
            base.AreaViewLocationFormats = new[]
             {
                "~Areas/{2}/Views/Themes/" + ViewTheme + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + ViewTheme + "/Shared/{0}.cshtml",
                "~Areas/{2}/Views/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Shared/{0}.cshtml"
               };
            base.AreaPartialViewLocationFormats = new[]
            {
                "~Areas/{2}/Views/Themes/" + ViewTheme + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + ViewTheme + "/Shared/{0}.cshtml",
                "~Areas/{2}/Views/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Shared/{0}.cshtml"
                };
        }



        public ThemeViewEngine()
        {
            ViewTheme = string.Empty;
        }

        public ThemeViewEngine(string activeThemeName)
        {
            SetViewTheme(activeThemeName);
        }
    }
}