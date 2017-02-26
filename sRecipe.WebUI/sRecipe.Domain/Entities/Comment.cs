using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int UserId { get; set; }
        public string Content { get; set; }

        [DefaultDateTimeValue("Now")]
        public DateTime? PostTime { get; set; }
        [DefaultValue(0)]
        public int Viewed { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public int? RecipeId { get; set; }
        public int? ParentId { get; set; }
        public virtual User User { get; set; }

    }
}
