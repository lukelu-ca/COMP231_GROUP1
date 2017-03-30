using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

        public DateTime? PostTime { get; set; }
        public int Viewed { get; set; }
        public bool IsDeleted { get; set; }
        public int? RecipeId { get; set; }
        public int? ParentId { get; set; }

    }
}