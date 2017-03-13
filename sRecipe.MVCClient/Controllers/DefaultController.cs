using Newtonsoft.Json;
using PagedList;
using sRecipe.MVCClient.Helpers;
using sRecipe.MVCClient.Models;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace sRecipe.MVCClient.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<ActionResult> Index(int? page = 1)
        {
            var client = sRecipeHttpClient.GetClient();
            var model = new RecipesListViewModel();
            HttpResponseMessage response = await client.GetAsync("api/recipes");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);
                var lstRecipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(content);
                var pagedList = new StaticPagedList<Recipe>(lstRecipes, pagingInfo.CurrentPage,
                      pagingInfo.PageSize, pagingInfo.TotalCount
                      );
                model.Recipes = pagedList;
                model.PagingInfo = pagingInfo;
            }
            else
            {
                return Content("An error ocurred.");
            }
            return View(model);
        }
    }
}
