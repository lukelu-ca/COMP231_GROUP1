using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class Direction
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public virtual Picture Picture { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? CreateTime { get; set; }

    }
}
