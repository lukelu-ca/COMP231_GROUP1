using AutoMapper.QueryableExtensions;
using sRecipe.Repository.Abstract;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Themes;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class DirectionsController : ThemeControllerBase
    {
        public DirectionsController(IsRecipeEFRepository repo) : base(repo)
        {
        }

        [ChildActionOnly]
        // GET: Directions
        public PartialViewResult Edit(int recipeId)
        {
            List<DirectionViewModel> directions = (_repo.GetDirections()).ProjectTo<DirectionViewModel>()
                .Where(s => s.RecipeId == recipeId)
                .OrderBy(s => s.Order)
                .ToList()
                ;
            if (directions == null || directions.Count == 0)
            {
                directions = new List<DirectionViewModel>();
                directions.Add(new DirectionViewModel());

            }
            else if (TempData["AddDirection"] != null && (bool)TempData["AddDirection"])
            {
                directions.Add(new DirectionViewModel());
            }
            TempData["AddDirection"] = false;
            DirectionListViewModel vm = new DirectionListViewModel()
            {
                Items = directions,
                RecipeId = recipeId
            };
            return PartialView("EditList", vm);
        }

        //[ChildActionOnly]
        //[HttpPost]
        //// GET: Directions
        //public PartialViewResult Edit(DirectionViewModel vm)
        //{

        //    return PartialView("EditList", vm);
        //}

        [ChildActionOnly]
        // GET: Directions
        public PartialViewResult List(int recipeId)
        {
            List<DirectionViewModel> directions = (_repo.GetDirections()).ProjectTo<DirectionViewModel>().Where(s => s.RecipeId == recipeId).ToList();
            return PartialView("List", directions);
        }
    }
}