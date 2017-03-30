using sRecipe.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Display(Name = "Cooking Time")]
        public int Cooking_Time { get; set; }
        [Display(Name = "Number of Services")]
        public int Number_of_Services { get; set; }
        public int Calorie { get; set; }
        [Display(Name = "Meal Type")]
        public int MealTypeId { get; set; }
        [Display(Name = "Meal Type")]
        public string MealTypeName { get; set; }
        public int Viewed { get; set; }
        public DateTime? PostTime { get; set; }
        public bool isPublic { get; set; }
        public int? PictureId { get; set; }
        public int UserId { get; set; }
        [Display(Name="Submitted By")]
        public string UserName { get; set; }

    }
}