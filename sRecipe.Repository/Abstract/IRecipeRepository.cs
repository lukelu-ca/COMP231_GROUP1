using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Abstract
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> Recipes { get;  }
        IEnumerable<User> Users { get;  }
        IEnumerable<Picture> Pictures { get;  }
        IEnumerable<MadeIt> MadeIts { get;  }
        IEnumerable<MealType> MealTypes { get;  }
        IEnumerable<MadeItProcess> MadeItProcesses { get;  }

  
        IEnumerable<Ingredient> Ingredients { get;  }
        IEnumerable<Favorite> Favorites { get;  }
        IEnumerable<Direction> Directions { get;  }
        IEnumerable<Comment> Comments { get;  }


    }
}
