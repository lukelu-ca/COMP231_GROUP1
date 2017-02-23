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
            //fill fileds of AccountViewModel
            AccountViewModel menuVM = new AccountViewModel();
            menuVM.isAuthenticated = Request.IsAuthenticated;
            
            if (User.Identity !=null && !string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                menuVM.User = repository.GetUserByEmail(User.Identity.Name);
                menuVM.IsAdmin = User.IsInRole("Administrator"); //repository.IsAdministrator(User.Identity.Name);
            }
            return PartialView(menuVM);
        }
    }
}