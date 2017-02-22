using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class MadeIt
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string Description { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual User User { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? PostTime { get; set; }
        public int Viewed { get; set; }

        public virtual ICollection<MadeItProcess> MadeItProcesses { get; set; }
    }
}
