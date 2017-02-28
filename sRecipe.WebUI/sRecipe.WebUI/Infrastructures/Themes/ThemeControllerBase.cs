using Ninject;
using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using sRecipe.WebUI.Infrastructures.ActionResults;
using sRecipe.WebUI.Infrastructures.Concrete;
using System;
using System.Collections;
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
        public virtual new sRecipePrincipal User
        {
            get;
            set;
        }
        public ActionResult XML(object model)
        {
            return new XMLResult(model);
        }

        public ActionResult CSV(IEnumerable model)
        {
            return new CSVResult(model, "Export");
        }
    }
}