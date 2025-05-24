using Libre_ERP_API.Data;
using Libre_ERP_API.DTO_s;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Libre_ERP_API.Services
{
    public class TimeZoneService
    {
        public async Task<(List<GetTimeZonesResponse> Result, int? ErrorId, string? ErrorDescription )> GetTimeZonesAsync()
        {

            var outputParams = new[]
{
                new SqlParameter("@ERROR_ID", SqlDbType.Int) { Direction = ParameterDirection.Output },
                new SqlParameter("@ERROR_DESCRIPTION", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output }
};

            var result = await CommandHelpers.ExecuteReaderAsync<GetTimeZonesResponse>(
                "SP_GET_TIME_ZONES",
                outputParams,
                reader => new GetTimeZonesResponse
                {
                    Id = reader.GetInt32(0),
                    Country = reader.GetString(1),
                    TimeZone = reader.GetString(2)
                });

            var errorId = (int?)outputParams[0].Value;
            var errorDescription = outputParams[1].Value?.ToString();

            if (errorId != null)
                return (new List<GetTimeZonesResponse>(), errorId, errorDescription);

            return result;
        }
    }
}
