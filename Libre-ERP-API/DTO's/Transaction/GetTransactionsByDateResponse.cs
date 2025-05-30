namespace Libre_ERP_API.DTO_s.Transaction
{
    public class ResTransaction : BaseResponse
    {
        public int IdTransaction { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }

    public class ResTransactionPaged : BaseResponse
    {
        public List<ResTransaction> Transactions { get; set; }
        public bool HasNextPage { get; set; }
    }
}
