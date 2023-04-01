using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Mail REQUIRED")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
