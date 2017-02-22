using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
