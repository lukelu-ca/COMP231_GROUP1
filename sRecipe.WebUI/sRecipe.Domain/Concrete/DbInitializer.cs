using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sRecipe.Domain.Entities;

namespace sRecipe.Domain.Concrete
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<sRecipeContext>
    {
        //Initiliaze data base
        protected override void Seed(sRecipeContext context)
        {
            new List<MealType>
            {
                new MealType { Name="Breakfast" }, //1
                new MealType { Name="Lunch" }, //2
                new MealType { Name="Dinner" }, //3
                new MealType { Name="Bread" }, //4
                new MealType { Name="Appetizar" }, //5
                new MealType { Name="MainCourse" }, //6
                new MealType { Name="Dessert" }  //7
            }.ForEach(s => context.MealTypes.Add(s));
            

            User u1 = new User { NickName="Admin", Role=Role.Administrator, Email="lukelu@live.ca", Password="111", Location="CA" };
            User u2 = new User { NickName = "M1", Role = Role.Membership, Email="t@t.com",Password="ttt", Location = "CA" };
            context.SaveChanges();

            MealType t1 = context.MealTypes.Where(s=> s.Id==1).FirstOrDefault();
            MealType t2 = context.MealTypes.Where(s => s.Id == 2).FirstOrDefault();
            MealType t3 = context.MealTypes.Where(s => s.Id == 3).FirstOrDefault();
            MealType t4 = context.MealTypes.Where(s => s.Id == 4).FirstOrDefault();
            MealType t5 = context.MealTypes.Where(s => s.Id == 5).FirstOrDefault();


            context.Recipes.Add(new Recipe { Name="Cookie 1", User=u1, MealType=t1, Calorie=1000, Number_of_Services=3, Viewed=1, Cooking_Time=30, isPublic=true });
            context.Recipes.Add(new Recipe { Name = "Cookie 2", User = u2, MealType = t2, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 3", User = u2, MealType = t2, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 4", User = u2, MealType = t3, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 5", User = u2, MealType = t4, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 6", User = u2, MealType = t5, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 7", User = u2, MealType = t3, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 8", User = u2, MealType = t4, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 9", User = u2, MealType = t3, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 10", User = u2, MealType = t3, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 11", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 12", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 13", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 14", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 15", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 16", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 17", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 18", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 19", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.Recipes.Add(new Recipe { Name = "Cookie 20", User = u2, MealType = t1, Calorie = 1000, Number_of_Services = 3, Viewed = 1, Cooking_Time = 30, isPublic = true });
            context.SaveChanges();


            Recipe c1 = context.Recipes.Where(s => s.Name == "Cookie 1").FirstOrDefault();
            Recipe c2 = context.Recipes.Where(s => s.Name == "Cookie 2").FirstOrDefault();
            Recipe c3 = context.Recipes.Where(s => s.Name == "Cookie 3").FirstOrDefault();
            Recipe c4 = context.Recipes.Where(s => s.Name == "Cookie 4").FirstOrDefault();

            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 1", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 2", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 3", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 4", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 5", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 6", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 7", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c1, Name = "Ing 8", Unit = "Cup", Quantity = "1/2" });

            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 1", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 2", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 3", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 4", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 5", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c2, Name = "Ing 6", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c3, Name = "Ing 7", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c3, Name = "Ing 8", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c3, Name = "Ing 1", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c3, Name = "Ing 2", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 3", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 4", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 5", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 6", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 7", Unit = "Cup", Quantity = "1/2" });
            context.Ingredients.Add(new Ingredient { Recipe = c4, Name = "Ing 8", Unit = "Cup", Quantity = "1/2" });
            context.SaveChanges();

            //new List<Recipe>
            //{

            //}.ForEach(s => context.Recipes.Add(s));

            //context.SaveChanges();
        }
    }
}
