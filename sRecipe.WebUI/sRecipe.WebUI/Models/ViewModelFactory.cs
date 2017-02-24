using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public static class ViewModelFactory
    {
        public static UserViewModel Create(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                NickName = user.NickName,
                CreateTime = user.CreateTime,
                Email = user.Email,
                Location = user.Location,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static User Parse(UserViewModel userVM)
        {
            return new User()
            {
                Id = userVM.Id,
                NickName = userVM.NickName,
                CreateTime = userVM.CreateTime,
                Email = userVM.Email,
                Location = userVM.Location,
                Password = userVM.Password,
                Role = userVM.Role
            };
        }
    }
}