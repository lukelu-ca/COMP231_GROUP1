using sRecipe.Repository.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace sRecipe.Repository.Entities
{
    public class User
    {
      
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultDateTimeValue("Now")]
        public DateTime? CreateTime { get; set; }
        public Role Role { get; set; }


        public virtual Profile Profile { get; set; }
    }
}
