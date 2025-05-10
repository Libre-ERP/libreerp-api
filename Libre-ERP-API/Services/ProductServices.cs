using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.Validators;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Libre_ERP_API.Services
{
    public class ProductServices
    {
        public async Task<(int IDReturn, int? ErrorID, string? ErrorDescription)> CreateProductAsync(CreateProductRequest req)
        {
            ProductValidator.ValidatePrice(req.Price);
        
            var parameters = new[]
            {
                new SqlParameter("@ID_USER", req.IDUser),
                new SqlParameter("@NAME", req.Name),
                new SqlParameter("@PRICE", req.Price),
                new SqlParameter("@MIN_STOCK", req.MinStock),
            };

            return await CommandHelpers.ExecuteNonQueryWithReturnAsync("SP_CREATE_PRODUCT", parameters);
        }

        public async Task<(int? ErrorID, string? ErrorDescription)> UpdateProductAsync(UpdateProductRequest req)
        {
            ProductValidator.ValidatePrice(req.Price);
            var parameters = new[]
{
                new SqlParameter("@ID_USER", req.IDUser),
                new SqlParameter("@ID_PRODUCT", req.IDProduct),
                new SqlParameter("@NAME", req.Name),
                new SqlParameter("@PRICE", req.Price),
                new SqlParameter("@MIN_STOCK", req.MinStock),
            };

            return await CommandHelpers.ExecuteNonQuery("SP_UPDATE_PRODUCT", parameters);
        }
        public async Task<GetProductResponse> GetProductsAsync(GetProductRequest req)
        {
            var parameters = new[]
            {
                new SqlParameter("@ID_USER", req.IDUser)
            };

            var (data, errorID, errorDescription) = await CommandHelpers.ExecuteReaderAsync<GetProductDTO>(
                "SP_GET_ACTIVE_PRODUCTS",
                parameters,
                reader => new GetProductDTO(
                    reader.GetInt32(reader.GetOrdinal("ID_PRODUCT")),
                    reader.GetString(reader.GetOrdinal("NAME")),
                    reader.GetInt32(reader.GetOrdinal("STOCK")),
                    reader.GetDecimal(reader.GetOrdinal("PRICE")),
                    reader.GetInt16(reader.GetOrdinal("MIN_STOCK"))
                )
            );

            return new GetProductResponse
            {
                ProductList = data,
                error = new BaseResponse
                {
                    ErrorID = errorID,
                    ErrorDescription = errorDescription
                }
            };
        }
    }
}
