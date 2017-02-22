using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public virtual User User { get; set; }

        public string Content { get; set; }

        [DefaultDateTimeValue("Now")]
        public DateTime? PostTime { get; set; }
        public int Viewed { get; set; }
        public bool IsDeleted { get; set; }

    }
}
