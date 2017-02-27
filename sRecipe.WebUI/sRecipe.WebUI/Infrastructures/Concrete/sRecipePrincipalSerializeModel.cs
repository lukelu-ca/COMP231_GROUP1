using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Infrastructures.Concrete
{
    public class sRecipePrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public Role Role { get; set; }
        public ProfileModel Profile { get; set; }
    }
}