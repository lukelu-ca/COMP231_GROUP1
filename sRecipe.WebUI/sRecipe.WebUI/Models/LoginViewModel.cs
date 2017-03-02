using sRecipe.Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace sRecipe.WebUI.Models
{
    public class LoginViewModel : LogData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}