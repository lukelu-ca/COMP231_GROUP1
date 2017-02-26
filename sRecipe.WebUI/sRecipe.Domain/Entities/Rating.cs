using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public double Stars { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? Rated_Time { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }

    }
}
