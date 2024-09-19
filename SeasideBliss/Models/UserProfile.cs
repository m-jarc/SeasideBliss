using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SeasideBliss.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "Contact number must be at least 10 digits.")]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Email must include '@' and a valid domain.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }
    }
}
