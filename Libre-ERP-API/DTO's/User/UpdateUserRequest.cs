using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s.User
{
    public class UpdateUserRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User")]
        public int IDUser { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public required string Name { get; set; }

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
