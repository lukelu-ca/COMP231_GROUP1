using sRecipe.Repository.ActionResults;
using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Abstract
{
   public interface IsRecipeEFRepository
    {
        RepositoryActionResult<Recipe> DeleteRecipe(int id);
        RepositoryActionResult<User> DeleteUser(int id);
        RepositoryActionResult<Ingredient> DeleteIngredient(int id);

        IQueryable<Recipe> GetRecipes();
        IQueryable<Recipe> GetRecipesWithIngredients();

        IQueryable<Recipe> GetRecipes(int userId);

        Recipe GetRecipe(int id);

        RepositoryActionResult<Recipe> InsertRecipe(Recipe rc);

        RepositoryActionResult<Recipe> UpdateRecipe(Recipe rc);

    }
}
