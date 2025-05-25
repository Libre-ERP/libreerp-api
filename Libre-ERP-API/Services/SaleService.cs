using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.Sale;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Libre_ERP_API.Services
{
    public class SaleService
    {
        public async Task<(int? ErrorID, string? ErrorDescription)> CreateSaleAsync(CreateSaleRequest req)
        {

            var saleDetailsTable = new DataTable();
            saleDetailsTable.Columns.Add("ID_PRODUCT", typeof(int));
            saleDetailsTable.Columns.Add("QUANTITY", typeof(int));

            foreach (var item in req.SaleDetails)
                saleDetailsTable.Rows.Add(item.IdProduct, item.Quantity);

            var parameters = new[]
            {
                new SqlParameter("@ID_USER", req.IdUser),
                new SqlParameter("@SALE_DETAILS", saleDetailsTable)
                {
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.SALE_DETAIL_TYPE"
                },
                new SqlParameter("@ERROR_ID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@ERROR_DESCRIPTION", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output }
            };

            await CommandHelpers.ExecuteNonQuery("SP_CREATE_SALE", parameters);

            var errorId = (int?)parameters[2].Value;
            var errorDesc = parameters[3].Value?.ToString();

            if (errorId != null)
            {
                return (errorId, errorDesc);
            }
            else
            {
                return (errorId, "Sale created successfully");

            }

        }
    }
}
