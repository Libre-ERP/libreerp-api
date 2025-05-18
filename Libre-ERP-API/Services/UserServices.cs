using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.User;
using Libre_ERP_API.Helpers;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;

namespace Libre_ERP_API.Services
{
    public class UserServices
    {
        private readonly PasswordHelper _passwordService;
        private readonly JWTHelper _jwtHelper;
        public UserServices(PasswordHelper passwordService, JWTHelper jwtHelper)
        {
            _passwordService = passwordService;
            _jwtHelper = jwtHelper;
        }

        

  
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


        public async Task<LoginResponse> LoginAsync(LoginRequest req)
        {
            var hashedPassword = _passwordService.HashPassword(req.Password);
            var parameters = new[]
            {
            new SqlParameter("@EMAIL", req.Email),
            new SqlParameter("@PASSWORD", hashedPassword)
            };

            var (data, errorID, errorDescription) = await CommandHelpers.ExecuteReaderAsync<LoginUserDTO>(
                "SP_LOGIN_USER",
                parameters,
                reader => new LoginUserDTO
                {
                    IdUser = reader.GetInt32(reader.GetOrdinal("ID_USER")),
                    Name = reader.GetString(reader.GetOrdinal("NAME")),
                    LangCode = reader.GetString(reader.GetOrdinal("LANG_CODE")),
                    CurrencyCode = reader.GetString(reader.GetOrdinal("CURRENCY_CODE"))
                }
            );

            if (errorID.HasValue || data.Count == 0)
            {
                return new LoginResponse
                {
                    Name = string.Empty,
                    LangCode = string.Empty,
                    CurrencyCode = string.Empty,
                    Token = null,
                    ErrorID = errorID ?? 1,
                    ErrorDescription = errorDescription ?? "Credenciales inválidas o error desconocido."
                };
            }

            var user = data[0];
            var token = _jwtHelper.GenerateToken(user.IdUser, user.Name);

            return new LoginResponse
            {
                Name = user.Name,
                LangCode = user.LangCode,
                CurrencyCode = user.CurrencyCode,
                Token = token,
                ErrorID = null,
                ErrorDescription = null
            };
        }

    }
}
