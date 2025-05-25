namespace Libre_ERP_API.DTO_s.Sale
{
    public class CreateSaleRequest
    {
        public int IdUser { get; set; }
        public List<SaleDetailItem> SaleDetails { get; set; }
    }
    public class SaleDetailItem
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
