using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    //sample: not use for this project
    public class IsRecipeMobile : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.Headers["x-sRecipeMobile"] != null;
        }
    }
}