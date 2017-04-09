using CacheCow.Server.CacheControlPolicy;
using CacheCow.Server.CacheRefreshPolicy;
using sRecipe.API.Helpers;
using sRecipe.Constants;
using sRecipe.Constants.Helpers;
using sRecipe.DTO.Models;
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
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace sRecipe.API.Controllers
{
    [RoutePrefix("api/recipes")]
    public class RecipesController : BaseApiController
    {
        const int maxPageSize = 10;

        public RecipesController(IsRecipeEFRepository repo) : base(repo)
        {
        }

        [Route("")]
        // GET api/<controller>
        public IHttpActionResult Get(
            //string sort = "id", int userId = 0
            //int page = 1, int pageSize = maxPageSize
            )
        {

            var recipes = TheRepository.GetRecipes()
                     //.ApplySort(sort)
                     //.Where(rc => (userId == 0 || rc.User.Id == userId))
                     .ToList()
                     .Select(s => TheModelFactory.Create(s));
            return Ok(recipes);

            //ensure the page size isn't lager than the maximu

            //if (pageSize > maxPageSize)
            //{
            //    pageSize = maxPageSize;
            //}

            ////caculate data from metadata
            //var totalCount = recipes.Count();
            //var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            //var urlHelper = new UrlHelper(Request);
            //var prevLink = page > 1 ? urlHelper.Link("",
            //    new
            //    {
            //        page = page - 1,
            //        pageSize = pageSize,
            //        sort = sort,
            //        userId = userId
            //    }) : "";
            //var nextLink = page < totalPages ? urlHelper.Link("",
            //    new
            //    {
            //        page = page + 1,
            //        pageSize = pageSize,
            //        sort = sort,
            //        userId = userId
            //    }) : "";


            //var paginationHeader = new PagingInfo()
            //{
            //    CurrentPage = page,
            //    PageSize = pageSize,
            //    TotalCount = totalCount,
            //    TotalPages = totalPages,
            //    PreviousPageLink = prevLink,
            //    NextPageLink = nextLink
            //};

            //HttpContext.Current.Response.Headers.Add(PagingInfo.PagingHeader,
            //   Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

            //var list = recipes
            //    .Skip(pageSize * (page - 1))
            //    .Take(pageSize)
            //    .ToList();

            // return result
            //return Ok(list);
        }

        // GET api/<controller>/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if (id != 0)
            {
                return Ok(TheModelFactory.Create(TheRepository.GetRecipe(id)));
            }
            else
            {
                return Ok(TheModelFactory.Create(new Recipe()
                {
                    Id = 0,
                    UserId = 1
                }
                    ));
            }
        }

        // POST api/<controller>
        [Route("")]
        public IHttpActionResult Post([FromBody]RecipeModel model)
        {
            var entity = TheModelFactory.Parse(model);
            if (entity == null) return NotFound();
            return Ok(TheModelFactory.Create(TheRepository.InsertRecipe(entity).Entity));
        }

        // PUT api/<controller>/5
        [HttpPut]
        [HttpPatch]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody]RecipeModel model)
        {
            var entity = TheModelFactory.Parse(model);
            var exist = TheRepository.GetRecipe(id);
            if (exist == null) return NotFound();
            return Ok(TheModelFactory.Create(TheRepository.UpdateRecipe(entity).Entity));
        }

        // DELETE api/<controller>/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var entity = TheRepository.GetRecipe(id);
            if (entity == null) return NotFound();
            return Ok(TheRepository.DeleteRecipe(id));
        }
    }
}