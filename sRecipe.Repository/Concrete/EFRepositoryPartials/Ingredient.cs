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

        #region Ingredient CRUD
        public RepositoryActionResult<Ingredient> InsertIngredient(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ingredient> GetIngredients()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Ingredient> UpdateIngredient(Ingredient entity)
        {
            throw new NotImplementedException();
        }
        public RepositoryActionResult<Ingredient> DeleteIngredient(int id)
        {
            return RepositoryActionResultExtensions<Ingredient, sRecipeContext>
                 .Delete(_ctx,
                         _ctx.Ingredients
                             .Where(s => s.Id == id)
                              .FirstOrDefault()
                         );
        }
        #endregion
    }
}
