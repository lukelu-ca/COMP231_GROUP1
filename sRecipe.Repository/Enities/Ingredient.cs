using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int? PictureId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual Recipe Recipe { get; set; }

    }
}
