using AutoMapper;
using Newtonsoft.Json;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Abstract;
using sRecipe.WebUI.Infrastructures.Concrete.SerializeModels;
using System;
using System.Web;
using System.Web.Security;

namespace sRecipe.WebUI.Infrastructures.Concrete
{
    /// <summary>
    /// Login, logout 
    /// Authentication method
    /// </summary>
    public class FormsAuthProvider : IAuthProvider
    {
        IUserRepository repository;
        public FormsAuthProvider(IUserRepository repo)
        {
            this.repository = repo;
        }
        public bool Authenticate(string email, string password, bool rememberMe = false)
        {

            bool result = repository.Authenticate(email, password);
            if (result)
            {
                User user = repository.GetUserByEmail(email);
                sRecipePrincipalSerializeModel userSearializeModel = 
                    Mapper.Map<User,sRecipePrincipalSerializeModel>(user);
         
                string userData = JsonConvert.SerializeObject(userSearializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                 1,
                                 email,
                                 DateTime.Now,
                                 DateTime.Now.AddMinutes(60),
                                 rememberMe, //pass here true, if you want to implement remember me functionality
                                 userData);
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                HttpContext.Current.Response.Cookies.Add(faCookie);
                // FormsAuthentication.SetAuthCookie(email, false);
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