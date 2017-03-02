using sRecipe.API.Helpers;
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
    public class RecipesController : ApiController
    {
        const int maxPageSize = 10;

        IsRecipeEFRepository _repo;

        public RecipesController()
        {
            _repo = new sRecipeEFRepository();
        }
        public RecipesController(IsRecipeEFRepository repo)
        {
            _repo = repo;
        }

        // GET api/<controller>
        public IHttpActionResult Get(
                string sort = "id", string userId = null,
                int page = 1, int pageSize = maxPageSize)
        {

            IQueryable<Recipe> recipes = null;
            recipes = _repo.GetRecipes();

            recipes = recipes.ApplySort(sort)
                    .Where(rc => (userId == null || rc.User.Id == Convert.ToInt32(userId)));

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


            var paginationHeader = new
            {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                previousPageLink = prevLink,
                nextPageLink = nextLink
            };

            HttpContext.Current.Response.Headers.Add("X-sRecipe",
               Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


            // return result
            return Ok(recipes
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList());
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