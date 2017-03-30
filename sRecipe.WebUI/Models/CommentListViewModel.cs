using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class CommentListViewModel : BaseListViewModel
    {
        public bool Owner;
        public List<CommentViewModel> Items { get; set; }
    }
}