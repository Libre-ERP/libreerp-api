using Libre_ERP_API.DTO_s;
using Libre_ERP_API.DTO_s.User;
using Libre_ERP_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libre_ERP_API.Controllers
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/user", async (CreateUserRequest dto, UserServices service) =>
            {
                try
                {
                    var result = await service.CreateUserAsync(dto);
                    return Results.Ok(new BaseResponse
                    {
                        ErrorID = result.ErrorID,
                        ErrorDescription = result.ErrorDescription
                    });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPost("/api/login", async (LoginRequest dto, UserServices service) =>
            {
                try
                {
                    var result = await service.LoginAsync(dto);

                    if (result.ErrorID.HasValue)
                    {
                        return Results.Unauthorized();
                    }

                    return Results.Ok(result); 
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }

            });
            app.MapPost("/api/user/update", async (UpdateUserRequest dto, UserServices service) =>
            {
                try
                {
                    var result = await service.UpdateUserAsync(dto);
                    return Results.Ok(new BaseResponse
                    {
                        ErrorID = result.ErrorID,
                        ErrorDescription = result.ErrorDescription
                    });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
        }

    }
}
