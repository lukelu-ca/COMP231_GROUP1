using sRecipe.Domain.Abstract;
using sRecipe.WebUI.Infrastructures.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace sRecipe.WebUI.Infrastructures.Concrete
{
    public class FormsAuthProvider : IAuthProvider 
    {
        IUserRepository repository;
        public FormsAuthProvider(IUserRepository repo)
        {
            this.repository = repo;
        }
        public bool Authenticate(string email, string password)
        {

            bool result = repository.Authenticate(email, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(email, false);
               

            }
            return result;
        }

        /// <summary>
        /// Logout and return to home page
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}