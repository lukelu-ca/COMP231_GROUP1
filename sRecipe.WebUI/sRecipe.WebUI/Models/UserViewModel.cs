using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sRecipe.WebUI.Models
{
    public class UserViewModel : User
    {

        [Required]
        [Remote("ValidateNickName", "Member", ErrorMessage = "NickName already exists.")]
        public override string NickName { get; set; }
        [Required]
        public override string Location { get; set; }
        [Required]
        [Remote("ValidateEmail", "Member", ErrorMessage ="Email already exists.")]
        public override string Email { get; set; }
        [Required]
        public override string Password { get; set; }
    }
}