using AutoMapper;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
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
        IAuthProvider _authProvider;
        IUserRepository _repo;
        public AccountController(IAuthProvider auth, IUserRepository repo)
        {
            _authProvider = auth;
            _repo = repo;
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
                //map loginview to LogData
                var data = Mapper.Map<LoginViewModel, LogData>(model);
                
                if (_authProvider.Authenticate(model.Email, model.Password))
                {
                    data.Success = true;
                    _repo.CreateLog(data);
                    return Redirect(returnUrl ?? Url.Action("Index", "Default"));
                }
                else
                {
                    data.Success = false;
                    _repo.CreateLog(data);
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
            _authProvider.Logout();
            return Redirect(Url.Action("Index", "Default"));
        }

    }
}
