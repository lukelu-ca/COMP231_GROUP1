using sRecipe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace sRecipe.WebUI.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nick name")]
        [Remote("ValidateNickName", "Member", ErrorMessage = "NickName already exists.")]
        public string NickName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        [Remote("ValidateEmail", "Member", ErrorMessage = "Email already exists.")]
        public string Email { get; set; }
        [Required]
        [MembershipPassword(
                MinRequiredNonAlphanumericCharacters = 1,
                MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
                ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
                MinRequiredPasswordLength =6
            )]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public Role Role { get; set; }
        public DateTime? CreateTime { get; set; }


    }
}