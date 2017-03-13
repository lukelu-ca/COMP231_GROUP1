using sRecipe.Repository.Abstract;
using sRecipe.Repository.Concrete;
using sRecipe.Repository.Entities;
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
        [Fact]
        public void Test()
        {
            var repo = new sRecipeEFRepository();
            User u = new User()
            {
                NickName = "t",
                Email = "S@S.S",
                Password = "1",
                Role = Role.Membership,
            };

            var r= repo.InsertUser(u);
            var  u1 = repo.GetUser(r.Entity.Id);
            u1.NickName = "U4";

            repo.UpdateUser(u);
            repo.DeleteUser(u1.Id);
            
            //IRecipeRepository db = new RecipeRepository();

            //var list = db.Recipes.FirstOrDefault();

        }
    }
}