using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s
{
    public class GetProductRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User")]
        public int? IDUser { get; set; }
    }
}
