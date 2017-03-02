using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Repository.Entities
{
    public class Profile
    {

        public int UserId { get; set; }
        public string Location { get; set; }
        public string ViewTheme { get; set; }
        public string ColorTheme { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
