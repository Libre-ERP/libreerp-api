namespace Libre_ERP_API.DTO_s.Transaction
{
    public class CreateTransactionRequest
    {
        public int IdUser { get; set; }
        public string Type { get; set; } // "In" or "Ex"
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
