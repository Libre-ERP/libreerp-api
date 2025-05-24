using Libre_ERP_API.DTO_s;
using Libre_ERP_API.Services;

namespace Libre_ERP_API.Controllers
{
    public static class TransactionEndpoint
    {
        public static void MapTransactionEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/transactions", async (CreateTransactionRequest req, TransactionService service) =>
            {
                var result = await service.CreateTransactionAsync(req);
                return result;
            });
        }

    }
}
