using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    /// <summary>
    /// write error log to database
    /// </summary>
    public class ExceptionLoggingFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Send ajax response
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        Message = "An error has occured. Please try again later.",
                    }
                };
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.ExceptionHandled = true;
            }


            //get Injection Repository
            IErrorLogRepository repo = DependencyResolver.Current.GetService<IErrorLogRepository>();

            //Log the error
            var error = new ErrorLog()
            {
                Message = filterContext.Exception.Message,
                StackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.Controller.GetType().Name,
                TargetedResult = filterContext.Result.GetType().Name,
                SessionId = (string)filterContext.HttpContext.Request["LoanId"],
                UserAgent = filterContext.HttpContext.Request.UserAgent,
                Timestamp = DateTime.Now
            };
            repo.Add(error);

            ////Send an email notification
            //MailMessage email = new MailMessage();
            //email.From = new MailAddress("lukelu@live.ca");
            //email.To.Add(new MailAddress(ConfigurationManager.AppSettings["ErrorEmail"]));
            //email.Subject = "An error has occured";
            //email.Body = filterContext.Exception.Message + Environment.NewLine
            //    + filterContext.Exception.StackTrace;
            //SmtpClient client = new SmtpClient("localhost");
            //client.Send(email);
        }
    }
}