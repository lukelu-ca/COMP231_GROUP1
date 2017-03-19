using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class RecipesListViewModel
    {
        public List<RecipeViewModel> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        [Display(Name = "Meal Type")]
        public int CurrentMealTypeID { get; set; }
        [Display( Name ="Recipe Name")]
        public string SearchName { get; set; }
    }
}