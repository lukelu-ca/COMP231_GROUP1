using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class DirectionViewModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Order { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? PictureId { get; set; }
    }
}