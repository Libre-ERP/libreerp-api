namespace Libre_ERP_API.DTO_s.Transaction
{
    public class GetFinancialTotalResponse : BaseResponse
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
    }
}
