using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.Transaction;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libre_ERP_API.Services
{
    public class TransactionService
    {
        public async Task<(int? ErrorID, string? ErrorDescription)> CreateTransactionAsync(CreateTransactionRequest req)
        {
            var parameters = new[]
            {
                new SqlParameter("@ID_USER", req.IdUser),
                new SqlParameter("@TYPE", req.Type),
                new SqlParameter("@AMOUNT", req.Amount),
                new SqlParameter("@DESCRIPTION", req.Description ?? (object)DBNull.Value),
                new SqlParameter("@ERROR_ID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@ERROR_DESCRIPTION", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output }
            };

            await CommandHelpers.ExecuteNonQuery("SP_CREATE_TRANSACTION", parameters);

            var errorId = (int?)parameters[4].Value;
            var errorDescription = parameters[5].Value?.ToString();

            if (errorId != null)
            {
                return (errorId, errorDescription);
            }
            else
            {
                return (errorId, "Transaction registered successfully");

            }

        }

        public async Task<GetFinancialTotalResponse> GetFinancialTotalByDateAsync(GetFinancialTotalRequest req)
        {
            var parameters = new[]
            {
                new SqlParameter("@ID_USER", req.IdUser),
                new SqlParameter("@START_DATE", req.StartDate),
                new SqlParameter("@END_DATE", req.EndDate),
                new SqlParameter("@TOTAL_INCOME", SqlDbType.Decimal) {Direction = ParameterDirection.Output},
                new SqlParameter("@TOTAL_EXPENSE", SqlDbType.Decimal) {Direction = ParameterDirection.Output} ,
                new SqlParameter("@ERROR_ID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@ERROR_DESCRIPTION", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output}
            };
            var data = await CommandHelpers.ExecuteReaderAsync<GetFinancialTotalResponse>(
                "SP_GET_FINANCIAL_TOTAL_BY_DATE", 
                parameters,
                reader => new GetFinancialTotalResponse
                {
                    TotalIncome = reader.GetDecimal(reader.GetOrdinal("TOTAL_INCOME")),
                    TotalExpense = reader.GetDecimal(reader.GetOrdinal("TOTAL_EXPENSE")),
                    ErrorID = reader.GetInt32(reader.GetOrdinal("ERROR_ID")),
                    ErrorDescription = reader.GetString(reader.GetOrdinal("ERROR_DESCRIPTION"))
                }
                );

            if (data.Data[2].ErrorID != null)
            {
                return new GetFinancialTotalResponse();
            }
            else
            {
                return new GetFinancialTotalResponse
                {
                    TotalIncome = data.Data[0].TotalIncome,
                    TotalExpense = data.Data[1].TotalExpense,
                    ErrorID = data.Data[2].ErrorID,
                    ErrorDescription = data.Data[3].ErrorDescription
                };

            }



        }

    }

}
