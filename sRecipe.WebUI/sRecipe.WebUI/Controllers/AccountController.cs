using sRecipe.Domain.Entities;
using sRecipe.WebUI.Infrastructures.Abstract;
using sRecipe.WebUI.Infrastructures.Themes;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class AccountController : ThemeControllerBase
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Email, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Default"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
 
        public ActionResult Logout()
        {
            authProvider.Logout();
            return Redirect(Url.Action("Index", "Default"));
        }

    }
}
