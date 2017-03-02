using sRecipe.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class Favorite
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int UserId { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? Favorite_Time { get; set; }
        [DefaultValue(false)]
        public bool Marked { get; set; }

        //public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }

    }
}
