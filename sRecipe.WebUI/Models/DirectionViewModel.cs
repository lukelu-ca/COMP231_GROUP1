using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class DirectionViewModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? PictureId { get; set; }
    }
}