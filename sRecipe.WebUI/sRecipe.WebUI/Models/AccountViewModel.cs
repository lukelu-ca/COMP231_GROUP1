using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{

    public class AccountViewModel
    {
        public User User;
        public bool IsAdmin;
        public bool isAuthenticated;
    }
}