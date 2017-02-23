using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using sRecipe.WebUI.Infrastructures.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;

namespace sRecipe.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        IRecipeRepository repository;
        public DefaultController(IRecipeRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
           
            return View(repository.Recipes.FirstOrDefault());
        }

        /// <summary>
        /// Sample action for a membership use
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public string Member()
        {
            return "This is the List action on the Home controller Member";
        }

        /// <summary>
        /// Sample action for only Administrator
        /// </summary>
        /// <returns></returns>
        [AdminAuth]
        public string Admin()
        {
            return "This is the List action on the Home controller Admin";
        }

        [Authorize(Roles ="Administrator")]
        public string Role()
        {
            return "This is the List action on the Home controller Role Administrator";
        }

    }
}