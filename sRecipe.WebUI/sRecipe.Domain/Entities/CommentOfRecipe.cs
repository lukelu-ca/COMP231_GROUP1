using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class CommentOfRecipe
    {
        [Key]
        public int Id { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
