using sRecipe.WebUI.Infrastructures.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Infrastructures.Abstract
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new sRecipePrincipal User
        {
            get { return base.User as sRecipePrincipal; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new sRecipePrincipal User
        {
            get { return base.User as sRecipePrincipal; }
        }
    }
}
