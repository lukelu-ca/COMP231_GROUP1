using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    /// <summary>
    ///sample: not use for this project
    /// webapi BASIC Authentication
    /// </summary>
    public class HttpAuthenticate : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var authHeader = filterContext.HttpContext.Request.Headers["Authorization"];
            if (!String.IsNullOrEmpty(authHeader))
            {
                var credentials = ASCIIEncoding.ASCII.GetString(
                    Convert.FromBase64String(authHeader.Replace("Basic", ""))).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                IUserRepository _repo = DependencyResolver.Current.GetService<IUserRepository>();
                if (_repo.Authenticate(username,password))
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}