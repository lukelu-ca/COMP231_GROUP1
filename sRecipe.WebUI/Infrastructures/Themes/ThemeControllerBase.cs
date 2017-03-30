using Ninject;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Controllers;
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
        protected IsRecipeEFRepository _repo;

        protected ThemeControllerBase(IsRecipeEFRepository repo)
        {
            _repo = repo;

        }

        public virtual new sRecipePrincipal User
        {
            get
            {
                return base.User as sRecipePrincipal;
            }
            set
            { }
        }

        protected List<SelectListItem>
                        GetSelectListItems<T>(IQueryable<T> list, 
                        string allText="" , string allValue="0",
                        string valueProperty = "Id",
                        string textProperty = "Name")
        {
            List<SelectListItem> sList = new List<SelectListItem>();
            if (allText != "") sList.Add(new SelectListItem()
            {
                Text = allText,
                Value = allValue
            });
            foreach (T item in list)
            {
                sList.Add(new SelectListItem()
                {
                    Text = item.GetType().GetProperty(textProperty).GetValue(item, null).ToString(),
                    Value = item.GetType().GetProperty(valueProperty).GetValue(item, null).ToString()
                });
            }
            return sList;
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