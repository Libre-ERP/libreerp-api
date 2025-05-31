namespace Libre_ERP_API.DTO_s.Transaction
{
    public class GetFinancialTotalRequest
    {
        public int IdUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
