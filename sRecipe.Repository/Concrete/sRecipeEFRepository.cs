using sRecipe.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;

namespace sRecipe.Repository.Concrete
{
    public class sRecipeEFRepository : IsRecipeEFRepository
    {
        sRecipeContext _ctx;
        public sRecipeEFRepository()
        {
            _ctx = new sRecipeContext();
        }
        public RepositoryActionResult<Ingredient> DeleteIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Recipe> DeleteRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Recipe> GetRecipes()
        {
            return _ctx.Recipes;
        }

        public IQueryable<Recipe> GetRecipes(int userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Recipe> GetRecipesWithIngredients()
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Recipe> InsertRecipe(Recipe rc)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Recipe> UpdateRecipe(Recipe rc)
        {
            throw new NotImplementedException();
        }
    }
}
