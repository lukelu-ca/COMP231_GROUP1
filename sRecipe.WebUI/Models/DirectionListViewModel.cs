using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class DirectionListViewModel : BaseListViewModel
    {
        public List<DirectionViewModel> Items { get; set; }
    }
}