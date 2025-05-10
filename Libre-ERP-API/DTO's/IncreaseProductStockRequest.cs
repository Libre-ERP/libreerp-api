using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s
{
    public class IncreaseProductStockRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User")]
        public int IDUser { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Product")]
        public int IDProduct { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; } 
    }
}
