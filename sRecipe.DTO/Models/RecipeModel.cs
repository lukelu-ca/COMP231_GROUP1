using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.DTO.Models
{
   public class RecipeModel : LinksBaseModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cooking_Time { get; set; }
        public int Number_of_Services { get; set; }
        public int Calorie { get; set; }
        public int MealTypeId { get; set; }
        public string MealTypeName { get; set; }
        public int Viewed { get; set; }
        public DateTime? PostTime { get; set; }
        public bool isPublic { get; set; }
        public int? PictureId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
