using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Infrastructures.Filters
{
    public enum RecipeWorkflowValues
    {
        Begin = 0,
        RecipeInfo=10,
        IngredientsInfo= 20,
        DirectionInfo =30,
        Final = 40
    }
}