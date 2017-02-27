using sRecipe.Domain.Abstract;
using sRecipe.Domain.Entities;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}