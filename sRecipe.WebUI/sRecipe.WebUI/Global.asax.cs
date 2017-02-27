using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using sRecipe.WebUI.App_Start;
using System.Web.Security;
using Newtonsoft.Json;
using sRecipe.WebUI.Infrastructures.Concrete;

namespace sRecipe.WebUI
{
    public class Global : HttpApplication
    {


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MappingConfig.RegisterMaps();
            ControllerConfig.SetControllerFactory(ControllerBuilder.Current);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                sRecipePrincipalSerializeModel userSerializeModel = JsonConvert.DeserializeObject<sRecipePrincipalSerializeModel>(authTicket.UserData);
                sRecipePrincipal userPrincipal = new sRecipePrincipal(authTicket.Name);
                userPrincipal.UserId = userSerializeModel.UserId;
                userPrincipal.NickName = userSerializeModel.NickName;
                userPrincipal.Role = userSerializeModel.Role;
                userPrincipal.Profile = userSerializeModel.Profile;
                HttpContext.Current.User = userPrincipal;
            }
        }
    }
}