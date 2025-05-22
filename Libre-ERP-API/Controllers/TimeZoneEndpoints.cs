using Libre_ERP_API.DTO_s;
using Libre_ERP_API.Services;

namespace Libre_ERP_API.Controllers
{
    public static class TimeZoneEndpoints
    {
        public static void MapTimeZoneEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/timezones", async (TimeZoneService service) =>
            {
                try
                {
                    var result = await service.GetTimeZonesAsync();
                    return Results.Ok(result);
                }catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                
            });
        }
    }
}
