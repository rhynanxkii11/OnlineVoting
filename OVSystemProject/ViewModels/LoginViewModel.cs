using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OVSystemProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remeber Me")]
        public bool RememberMe { get; set; }
    }
}
