using sRecipe.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cooking_Time { get; set; }
        public int Number_of_Services { get; set; }
        public int Calorie { get; set; }
        public int MealTypeId { get; set; }
        public int Viewed { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? PostTime { get; set; }
        public bool isPublic { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual MealType MealType { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }
        public virtual ICollection<MadeIt> MadeIts { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


    }
}
