using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    public class RecipeWorkflowFilter : FilterAttribute, IActionFilter
    {
        //private int _highestCompletedStage;
        public int MinRequiredStage { get; set; }
        public int CurrentStage { get; set; }


        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}