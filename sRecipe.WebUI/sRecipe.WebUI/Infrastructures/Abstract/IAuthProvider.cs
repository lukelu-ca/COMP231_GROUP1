using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Infrastructures.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string email, string password);
    }
}