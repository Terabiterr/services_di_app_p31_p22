using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace services_di_app.Models
{
    public class User : Model
    {
        [Required(ErrorMessage = "Name is required ...")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "The name required max: 255, min: 2")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required ...")]
        [StringLength(100, ErrorMessage = "The e-mail very long ...")]
        [EmailAddress(ErrorMessage = "Incorrect format ...")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required ...")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "The password required max: 255, min: 2")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "The password required [A-Z] or min: 6")]
        public string Password { get; set; } = string.Empty;

    }
}
