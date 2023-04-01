using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Mail REQUIRED")]
        [EmailAddress(ErrorMessage = "YOU MUST ADD VALID Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PASSWORD REQUIRED")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Min len 5")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
