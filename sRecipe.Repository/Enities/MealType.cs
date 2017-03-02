using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class MealType
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
