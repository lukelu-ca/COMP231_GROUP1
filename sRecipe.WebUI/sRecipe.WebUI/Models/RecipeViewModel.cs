using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cooking_Time { get; set; }
        public int Number_of_Services { get; set; }
        public int Calorie { get; set; }
        public int MealTypeId { get; set; }
        public int Viewed { get; set; }
        public DateTime PostTime { get; set; }
        public bool isPublic { get; set; }
        public int PictureId { get; set; }

    }
}