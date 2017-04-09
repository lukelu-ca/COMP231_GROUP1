using sRecipe.DTO;
using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sRecipe.API.Helpers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;
        private IsRecipeEFRepository _db;

        public BaseApiController(IsRecipeEFRepository repo)
        {
            _db = repo;
        }

        protected IsRecipeEFRepository TheRepository
        {
            get
            {
                return _db;
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request);

                }
                return _modelFactory;
            }
        }
    }
}
