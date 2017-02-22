using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sRecipe.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? CreateTime { get; set; }
    }
}
