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
    public class MemberController : Controller
    {
        IUserRepository UserRepo;

        public MemberController(IUserRepository repo)
        {
            this.UserRepo = repo;
        }
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<UserViewModel,User>(model);
                UserRepo.CreateUser(user);
                return Redirect(Url.Action("Index", "Default"));
            }
            else
            {
                return View();
            }
        }

        public JsonResult ValidateEmail(string Email)
        {
            return Json(!UserRepo.IsEmailExist(Email), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ValidateNickName(string NickName)
        {
            return Json(!UserRepo.IsNickNameExist(NickName), JsonRequestBehavior.AllowGet);
        }
    }
}