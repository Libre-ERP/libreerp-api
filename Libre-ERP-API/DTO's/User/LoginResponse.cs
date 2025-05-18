namespace Libre_ERP_API.DTO_s.User
{
    public class LoginResponse : BaseResponse
    {
        public required string Name { get; set; }
        public required string LangCode { get; set; }
        public required string CurrencyCode { get; set; }
        public string? Token { get; set; }

    }
}
