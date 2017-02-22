using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
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

        [Authorize]
        // GET: Default
        public ActionResult Index()
        {
           
            return View(repository.Recipes.FirstOrDefault());
        }


    }
}