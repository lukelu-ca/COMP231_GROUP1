using sRecipe.API.Helpers;
using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sRecipe.API.Controllers
{
    [RoutePrefix("api/mealtypes")]
    public class MealTypeController : BaseApiController
    {
        public MealTypeController(IsRecipeEFRepository repo) : base(repo)
        {

        }
        [Route("")]
        // GET api/<controller>
        public IHttpActionResult Get(
         //string sort = "id", int userId = 0
         //int page = 1, int pageSize = maxPageSize
         )
        {

            var list = TheRepository.GetMealTypes()
                     //.ApplySort(sort)
                     //.Where(rc => (userId == 0 || rc.User.Id == userId))
                     .ToList()
                     .Select(s => TheModelFactory.Create(s));
            return Ok(list);

        }
    }
}