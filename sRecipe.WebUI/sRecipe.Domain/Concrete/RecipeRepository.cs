using sRecipe.Domain.Abstract;
using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Concrete
{
    public class RecipeRepository : IRecipeRepository
    {
        private sRecipeContext context = new sRecipeContext();

        public IEnumerable<Recipe> Recipes { get { return context.Recipes; } }
        public IEnumerable<User> Users { get { return context.Users; } }
        public IEnumerable<Picture> Pictures { get { return context.Pictures; } }
        public IEnumerable<MadeIt> MadeIts { get { return context.MadeIts; } }
        public IEnumerable<MealType> MealTypes { get { return context.MealTypes; } }
        public IEnumerable<MadeItProcess> MadeItProcesses { get { return context.MadeItProcesses; } }
        public IEnumerable<Ingredient> Ingredients { get { return context.Ingredients; } }
        public IEnumerable<Favorite> Favorites { get { return context.Favorites; } }
        public IEnumerable<Direction> Directions { get { return context.Directions; } }
        public IEnumerable<Comment> Comments { get { return context.Comments; } }
        public IEnumerable<CommentOfComment> CommentOfComments { get { return context.CommentOfComments; } }
        public IEnumerable<CommentOfRecipe> CommentOfRecipes { get { return context.CommentOfRecipes; } }

    }
}
