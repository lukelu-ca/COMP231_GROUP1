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
        //Recipe CRUD Methods
        RepositoryActionResult<Recipe> InsertRecipe(Recipe entity);
        IQueryable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        RepositoryActionResult<Recipe> UpdateRecipe(Recipe entity);
        RepositoryActionResult<Recipe> DeleteRecipe(int id);

        //Recipe Special Methods
        IQueryable<Recipe> GetRecipesWithIngredients();
        IQueryable<Recipe> GetRecipes(int userId);


        //User CRUD Methods
        RepositoryActionResult<User> InsertUser(User entity);
        IQueryable<User> GetUsers();
        User GetUser(int id);
        RepositoryActionResult<User> UpdateUser(User entity);
        RepositoryActionResult<User> DeleteUser(int id);


        //Ingredient CRUD Method
        RepositoryActionResult<Ingredient> InsertIngredient(Ingredient entity);
        IQueryable<Ingredient> GetIngredients();
        Ingredient GetIngredient(int id);
        RepositoryActionResult<Ingredient> UpdateIngredient(Ingredient entity);
        RepositoryActionResult<Ingredient> DeleteIngredient(int id);


        //Comment CRUD Method
        RepositoryActionResult<Comment> InsertComment(Comment entity);
        IQueryable<Comment> GetComments();
        Comment GetComment(int id);
        RepositoryActionResult<Comment> UpdateComment(Comment entity);
        RepositoryActionResult<Comment> DeleteComment(int id);

        //MealType CRUD Method
        RepositoryActionResult<MealType> InsertMealType(MealType entity);
        IQueryable<MealType> GetMealTypes();
        MealType GetMealType(int id);
        RepositoryActionResult<MealType> UpdateMealType(MealType entity);
        RepositoryActionResult<MealType> DeleteMealType(int id);


    }
}
