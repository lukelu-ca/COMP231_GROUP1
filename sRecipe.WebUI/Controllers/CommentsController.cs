using AutoMapper.QueryableExtensions;
using sRecipe.Repository.Abstract;
using sRecipe.WebUI.Infrastructures.Themes;
using sRecipe.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Controllers
{
    public class CommentsController : ThemeControllerBase
    {
        public CommentsController(IsRecipeEFRepository repo) : base(repo)
        {

        }

        [ChildActionOnly]
        // GET: Comments
        public PartialViewResult List(int recipeId, bool owner)
        {
            List<CommentViewModel> comments = (_repo.GetComments())
                .ProjectTo<CommentViewModel>()
                .Where(s => s.RecipeId == recipeId)
                .OrderBy(s => s.PostTime)
                .ToList();

            if (!owner) comments = comments.Where(o => o.IsDeleted == false).ToList();

            if (comments == null)
            {
                comments = new List<CommentViewModel>();
            }
            comments.Add(new CommentViewModel());

            CommentListViewModel vm = new CommentListViewModel()
            {
                Items = comments,
                RecipeId = recipeId,
                Owner = owner
            };

            return PartialView("List", vm);
        }
    }
}