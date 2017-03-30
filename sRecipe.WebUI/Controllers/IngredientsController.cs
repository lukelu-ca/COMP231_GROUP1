using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sRecipe.Repository.Abstract;
using sRecipe.WebUI.Models;
using AutoMapper.QueryableExtensions;
using sRecipe.WebUI.Infrastructures.Themes;

namespace sRecipe.WebUI.Controllers
{
    public class IngredientsController : ThemeControllerBase
    {
        public IngredientsController(IsRecipeEFRepository repo) : base(repo)
        {
        }

        [ChildActionOnly]
        // GET: Directions
        public PartialViewResult Edit(int recipeId)
        {
            List<IngredientViewModel> ingredients = (_repo.GetIngredients())
                .ProjectTo<IngredientViewModel>()
                .Where(s => s.RecipeId == recipeId)
                .ToList();
            if (ingredients == null || ingredients.Count == 0)
            {
                ingredients = new List<IngredientViewModel>();
                ingredients.Add(new IngredientViewModel());

            }
            else if (TempData["AddIngredient"] != null && (bool)TempData["AddIngredient"])
            {
                ingredients.Add(new IngredientViewModel());
            }
            TempData["AddIngredient"] = false;
            IngredientListViewModel vm = new IngredientListViewModel()
            {
                Items = ingredients,
                RecipeId = recipeId
            };

            return PartialView("EditList", vm);
        }


        // GET: Ingredients
        [ChildActionOnly]
        public PartialViewResult List(int recipeId)
        {
            List<IngredientViewModel> ingredients = (_repo.GetIngredients()).ProjectTo<IngredientViewModel>().Where(s => s.RecipeId == recipeId).ToList();
            return PartialView("List", ingredients);
        }
    }
}