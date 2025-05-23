namespace Libre_ERP_API.DTO_s
{
    public class GetTimeZonesResponse : BaseResponse
    {
        public byte Id { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
    }
}
