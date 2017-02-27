using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Themes
{
    public class ThemeViewEngine : RazorViewEngine
    {
        public string ThemeName { get; set; }

        public void SetThemeName(string value)
        {
            this.ThemeName = value;
            base.ViewLocationFormats = new[]
           {
                "~/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            base.PartialViewLocationFormats = new[]
           {
                "~/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
                "~/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
               };
            base.AreaViewLocationFormats = new[]
             {
                "~Areas/{2}/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml",
                "~Areas/{2}/Views/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Shared/{0}.cshtml"
               };
            base.AreaPartialViewLocationFormats = new[]
            {
                "~Areas/{2}/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml",
                "~Areas/{2}/Views/{1}/{0}.cshtml",
                "~Areas/{2}/Views/Shared/{0}.cshtml"
                };
        }



        public ThemeViewEngine()
        {
            ThemeName = string.Empty;
        }

        public ThemeViewEngine(string activeThemeName)
        {
            SetThemeName(activeThemeName);

            //ViewLocationFormats = new[]
            //   {
            //    "~/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
            //    "~/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml"
            //    };

            //PartialViewLocationFormats = new[]
            //{
            //    "~/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
            //    "~/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml"
            //};

            //AreaViewLocationFormats = new[]
            //{
            //    "~Areas/{2}/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
            //    "~Areas/{2}/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml"
            //};

            //AreaPartialViewLocationFormats = new[]
            //{
            //    "~Areas/{2}/Views/Themes/" + ThemeName + "/{1}/{0}.cshtml",
            //    "~Areas/{2}/Views/Themes/" + ThemeName + "/Shared/{0}.cshtml"
            //};
        }
    }
}