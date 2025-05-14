using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s.User
{
    public class CreateUserRequest
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        [StringLength(150, ErrorMessage = "Email must be less than 150 characters")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 255 characters")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "CurrencyCode is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CurrencyCode must be exactly 3 characters (ISO code)")]
        public required string CurrencyCode { get; set; }

        [Required(ErrorMessage = "LangCode is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "LangCode must be exactly 2 characters (ISO code)")]
        public required string LangCode { get; set; }

        [Range(1, byte.MaxValue, ErrorMessage = "Invalid Time Zone ID")]
        public int IDTimeZone { get; set; }
    }
}
