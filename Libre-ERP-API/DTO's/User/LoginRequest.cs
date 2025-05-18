using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s.User
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(150, ErrorMessage = "Email must be less than 150 characters.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [MaxLength(100, ErrorMessage = "Password must be less than 100 characters.")]
        public required string Password { get; set; }

    }
}
