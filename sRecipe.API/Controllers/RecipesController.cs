using sRecipe.API.Helpers;
using sRecipe.Constants.Helpers;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace sRecipe.API.Controllers
{
    public class RecipesController : ApiControllerBase
    {
        const int maxPageSize = 10;

        [Route("api/recipes", Name = "RecipesList")]
        // GET api/<controller>
        public IHttpActionResult Get(
                string sort = "id", int userId = 0,
                int page = 1, int pageSize = maxPageSize)
        {

            IQueryable<Recipe> recipes = null;
            recipes = _repo.GetRecipes();

            recipes = recipes.ApplySort(sort)
                    .Where(rc => (userId == 0 || rc.User.Id == userId));

            //ensure the page size isn't lager than the maximu

            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            //caculate data from metadata
            var totalCount = recipes.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 1 ? urlHelper.Link("RecipesList",
                new
                {
                    page = page - 1,
                    pageSize = pageSize,
                    sort = sort,
                    userId = userId
                }) : "";
            var nextLink = page < totalPages ? urlHelper.Link("RecipesList",
                new
                {
                    page = page + 1,
                    pageSize = pageSize,
                    sort = sort,
                    userId = userId
                }) : "";


            var paginationHeader = new PagingInfo()
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                PreviousPageLink = prevLink,
                NextPageLink = nextLink
            };

            HttpContext.Current.Response.Headers.Add(PagingInfo.PagingHeader,
               Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
            var list = recipes
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            // return result
            return Ok(list);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}