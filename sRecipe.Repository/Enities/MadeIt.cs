using sRecipe.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class MadeIt
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public int? PictureId { get; set; }
        public int UserId { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? PostTime { get; set; }
        [DefaultValue(0)]
        public int Viewed { get; set; }

        //public virtual Recipe Recipe { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<MadeItProcess> MadeItProcesses { get; set; }
    }
}
