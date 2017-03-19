using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace sRecipe.API.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
       protected IsRecipeEFRepository _repo;

        public ApiControllerBase()
        {
            _repo = new sRecipeEFRepository();
        }
        public ApiControllerBase(IsRecipeEFRepository repo)
        {
            _repo = repo;
        }


    }
}
