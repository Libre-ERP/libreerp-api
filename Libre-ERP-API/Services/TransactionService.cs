using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.Transaction;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;

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

        public async Task<(ResTransactionPaged, int? ErrorID, string? ErrorDescription)> GetTransactionsByDateAsync(ReqGetTransactionsByDate req)
        {
            var parameters = new[]
            {
                new SqlParameter("@ID_USER", SqlDbType.Int) { Value = req.IdUser },
                new SqlParameter("@START_DATE", SqlDbType.DateTime) { Value = req.StartDate },
                new SqlParameter("@END_DATE", SqlDbType.DateTime) { Value = req.EndDate },
                new SqlParameter("@PAGE_NUMBER", SqlDbType.Int) { Value = req.PageNumber }
            };
            var outputParams = new[]
            {
                new SqlParameter("@ERROR_ID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@ERROR_DESCRIPTION", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output },
                new SqlParameter("@HAS_NEXT_PAGE", SqlDbType.Bit) { Direction = ParameterDirection.Output }
            };

            var result = await CommandHelpers.ExecuteReaderAsync<ResTransaction>(
                "SP_GET_TRANSACTIONS_BY_DATE",
                parameters.Concat(outputParams).ToArray(),
                reader => new ResTransaction
                {
                    IdTransaction = reader.GetInt32(0),
                    Type = reader.GetString(1),
                    Date = reader.GetDateTime(2),
                    Amount = reader.GetDecimal(3),
                    Description = reader.IsDBNull(4) ? null : reader.GetString(4)
                });

            var hasNext = (bool?)outputParams[2].Value ?? false;
            var errorId = (int?)outputParams[0].Value;
            var errorDescription = outputParams[1].Value?.ToString();

            if (errorId != null)
                return (new ResTransactionPaged(), errorId, errorDescription);

            return (new ResTransactionPaged
            {
                Transactions = result.Data,
                HasNextPage = hasNext
            }, errorId, errorDescription);
        }

    }

}
