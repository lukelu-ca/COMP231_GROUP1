using PagedList;
using sRecipe.Constants.Helpers;
using sRecipe.MVCClient.Helpers;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.MVCClient.Models
{
    public class RecipesListViewModel
    {
        public IPagedList<Recipe> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}