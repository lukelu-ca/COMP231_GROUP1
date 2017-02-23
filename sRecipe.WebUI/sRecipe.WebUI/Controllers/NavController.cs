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
        IUserRepository repository;

        public NavController(IUserRepository repo)
        {
            this.repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu()
        {
            AccountViewModel menuVM = new AccountViewModel();
            menuVM.isAuthenticated = Request.IsAuthenticated;
            if (User.Identity !=null && User.Identity.Name!="")
            {
                menuVM.user = repository.Users.Where(s => s.Email == User.Identity.Name).FirstOrDefault();
                menuVM.IsAdmin = (menuVM.user.Role== Role.Administrator);
            }
            return PartialView(menuVM);
        }
    }
}