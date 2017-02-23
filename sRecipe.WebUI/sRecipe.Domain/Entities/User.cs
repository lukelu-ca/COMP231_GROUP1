using sRecipe.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace sRecipe.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public virtual string NickName { get; set; }
        public virtual string Location { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Role Role { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? CreateTime { get; set; }
    }
}
