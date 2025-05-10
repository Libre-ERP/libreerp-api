using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s
{
    public class DeactivateProductRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid User")]
        public int IDUser { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Product")]
        public int IDProduct { get; set; }
    }
}
