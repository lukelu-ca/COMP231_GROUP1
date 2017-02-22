using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? Favorite_Time { get; set; }
        public bool Marked { get; set; }
    }
}
