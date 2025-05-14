using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.User;
using Libre_ERP_API.Helpers;
using Microsoft.Data.SqlClient;

namespace Libre_ERP_API.Services
{
    public class UserServices
    {
        private readonly PasswordHelper _passwordService;
        public UserServices(PasswordHelper passwordService) => _passwordService = passwordService;
        public async Task<(int? ErrorID, string? ErrorDescription)> CreateUserAsync(CreateUserRequest req)
        {

            var hashedPassword = _passwordService.HashPassword(req.Password);

            var parameters = new[]
            {
            new SqlParameter("@NAME", req.Name),
            new SqlParameter("@EMAIL", req.Email),
            new SqlParameter("@PASSWORD", hashedPassword),
            new SqlParameter("@CURRENCY_CODE", req.CurrencyCode),
            new SqlParameter("@LANG_CODE", req.LangCode),
            new SqlParameter("@ID_TIME_ZONE", req.IDTimeZone)

        };

            return await CommandHelpers.ExecuteNonQuery("SP_CREATE_USER", parameters);
        }
    }
}
