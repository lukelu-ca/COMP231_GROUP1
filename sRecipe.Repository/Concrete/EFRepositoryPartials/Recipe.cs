using sRecipe.Repository.Abstract;
using System;
using System.Linq;
using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;
using sRecipe.Repository.Helpers;

namespace sRecipe.Repository.Concrete
{
    public partial class sRecipeEFRepository : IsRecipeEFRepository
    {

        #region Recipe CRUD

        public Recipe GetRecipe(int id)
        {
            return _ctx.Recipes.Where(s => s.Id == id).FirstOrDefault();
        }

        public IQueryable<Recipe> GetRecipes()
        {
            return _ctx.Recipes;
        }
        public RepositoryActionResult<Recipe> InsertRecipe(Recipe entity)
        {
            return RepositoryActionResultExtensions<Recipe, sRecipeContext>
                        .Insert(_ctx,
                                _ctx.Recipes,
                                entity
                                );
        }
        public RepositoryActionResult<Recipe> UpdateRecipe(Recipe entity)
        {
            return RepositoryActionResultExtensions<Recipe, sRecipeContext>
                 .Update(_ctx,
                         _ctx.Recipes,
                         _ctx.Recipes
                             .Where(s => s.Id == entity.Id)
                              .FirstOrDefault(),
                         entity
                         );
        }
        public RepositoryActionResult<Recipe> DeleteRecipe(int id)
        {
            return RepositoryActionResultExtensions<Recipe, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Recipes,
                         _ctx.Recipes
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }

        #endregion

        #region Recipe Specifical
        public IQueryable<Recipe> GetRecipes(int userId)
        {
            return _ctx.Recipes.Where(s => s.UserId == userId);

        }

        public IQueryable<Recipe> GetRecipesWithIngredients()
        {
            return _ctx.Recipes.Include("Ingredients");
        }
        #endregion
    }
}
