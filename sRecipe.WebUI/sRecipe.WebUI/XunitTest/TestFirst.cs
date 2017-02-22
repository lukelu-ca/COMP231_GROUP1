using sRecipe.Domain.Abstract;
using sRecipe.Domain.Concrete;
using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;

namespace sRecipe.WebUI.XunitTest
{
    public class TestFirst
    {
        [Theory]
        public void Test(IRecipeRepository db)
        {
            
            var list = db.Recipes.FirstOrDefault();
            

        }
    }
}