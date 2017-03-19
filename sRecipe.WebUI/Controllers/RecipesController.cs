using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sRecipe.Repository.Concrete;
using sRecipe.WebUI.Models;
using sRecipe.Repository.Abstract;
using AutoMapper;
using sRecipe.Repository.Entities;
using sRecipe.WebUI.Infrastructures.Themes;
using AutoMapper.QueryableExtensions;

namespace sRecipe.WebUI.Controllers
{
    public class RecipesController : ThemeControllerBase
    {
        private IsRecipeEFRepository _repo;

        public RecipesController(IsRecipeEFRepository repo)
        {
            _repo = repo;
            ViewData["MealTypeList"] = GetSelectListItems
                            (_repo.GetMealTypes()
                                .ProjectTo<MealTypeViewModel>()
                             );
            ViewData["MealTypeListAll"] = GetSelectListItems
                         (_repo.GetMealTypes()
                             .ProjectTo<MealTypeViewModel>(),
                             "ALL Meal Type"
                          );
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(RecipesListViewModel recipeListVM)
        {
            var list
                 = (_repo.GetRecipes())
                .ProjectTo<RecipeViewModel>()
                .Where(r => r.isPublic).ToList();

            if (recipeListVM.CurrentMealTypeID != 0)
            {
                list = (from l in list
                        where l.MealTypeId == recipeListVM.CurrentMealTypeID
                        select l).ToList();
            }

            if (!string.IsNullOrEmpty(recipeListVM.SearchName))
            {
                list = list.Where(r => r.Name.Contains(recipeListVM.SearchName)).ToList();
            }
            recipeListVM.Recipes = list;
            return View(recipeListVM);
        }

        // GET: Recipes
        public ActionResult Index(bool onlyOwner = false)
        {
            var list = (_repo.GetRecipes()).ProjectTo<RecipeViewModel>();
            //For Administrator, show all recipes even there are private.
            if (User != null && User.Role == Role.Administrator)
            {
                if (onlyOwner)
                    return View(list.Where(r => r.UserId == User.UserId));
                else
                    return View(list);
            }
            //For membership user, show all public recipe and show recipes which were posted by the member
            else if (User != null && User.Role == Role.Membership)
            {
                if (onlyOwner)
                    return View(list.Where(r => r.UserId == User.UserId));
                else
                    return View(list.Where(r => r.UserId == User.UserId || r.isPublic));
            }
            //For anonymous user, show all public recipes
            else
            {
                return View((_repo.GetRecipes()).ProjectTo<RecipeViewModel>().Where(r => r.isPublic));
            }
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id, bool returnSearch = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = Mapper.Map<Recipe, RecipeViewModel>(_repo.GetRecipe(Convert.ToInt32(id)));

            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReturnSearch = returnSearch;
            return View(recipeViewModel);
        }

        [Authorize]
        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Cooking_Time,Number_of_Services,Calorie,MealTypeId,Viewed,PostTime,isPublic,PictureId,UserId")] RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                recipeViewModel.UserId = User.UserId;
                recipeViewModel.PostTime = DateTime.Now;
                _repo.InsertRecipe(Mapper.Map<RecipeViewModel, Recipe>(recipeViewModel));
                return RedirectToAction("Index");
            }

            return View(recipeViewModel);
        }

        [Authorize]
        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = Mapper.Map<Recipe, RecipeViewModel>(_repo.GetRecipe(Convert.ToInt32(id)));
            if (recipeViewModel == null || recipeViewModel.UserId != User.UserId)
            {
                return HttpNotFound();
            }
            return View(recipeViewModel);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Cooking_Time,Number_of_Services,Calorie,MealTypeId,Viewed,PostTime,isPublic,PictureId,UserId")] RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateRecipe(Mapper.Map<RecipeViewModel, Recipe>(recipeViewModel));
                return RedirectToAction("Index");
            }
            return View(recipeViewModel);
        }

        // GET: Recipes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool returnSearch = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = Mapper.Map<Recipe, RecipeViewModel>(_repo.GetRecipe(Convert.ToInt32(id)));
            if (recipeViewModel == null || recipeViewModel.UserId != User.UserId)
            {
                return HttpNotFound();
            }
            ViewBag.ReturnSearch = returnSearch;
            return View(recipeViewModel);
        }

        // POST: Recipes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteRecipe(id);
            return RedirectToAction("Index");
        }

    }
}
