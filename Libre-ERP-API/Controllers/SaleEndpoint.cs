using Libre_ERP_API.DTO_s.Sale;
using Libre_ERP_API.Services;
using System.Runtime.CompilerServices;

namespace Libre_ERP_API.Controllers
{
    public static class SaleEndpoint
    {

        public static async void MapSaleEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/sales", async (CreateSaleRequest req, SaleService service) =>
            {
                var result = await service.CreateSaleAsync(req);
                return result;
            });
        }
    }
}
