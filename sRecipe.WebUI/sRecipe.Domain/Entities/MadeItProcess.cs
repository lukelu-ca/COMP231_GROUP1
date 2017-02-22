using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class MadeItProcess
    {
        [Key]
        public int Id { get; set; }
        public virtual MadeIt MadeIt { get; set; }
        public virtual Picture Picture { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
