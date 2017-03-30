using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sRecipe.WebUI.Models
{
    public class IngredientListViewModel : BaseListViewModel
    {
        public List<IngredientViewModel> Items { get; set; }
    }
}