using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.DTO.Models
{
   public abstract class LinksBaseModel
    {
        public ICollection<LinkModel> Links { get; set; }

    }
}
