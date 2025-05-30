using System.ComponentModel.DataAnnotations;

namespace Libre_ERP_API.DTO_s.Transaction
{
    public class ReqGetTransactionsByDate
    {
        public int IdUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid Page Number")]
        public int PageNumber { get; set; }
    }
}
