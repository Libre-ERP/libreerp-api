namespace Libre_ERP_API.DTO_s.User
{
    public class LoginUserDTO
    {
        public int IdUser { get; set; }
        public required string Name { get; set; }
        public required string LangCode { get; set; }
        public required string CurrencyCode { get; set; }
    }
}
