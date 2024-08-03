using Microsoft.AspNetCore.Mvc;
using SomoSSolar.API.Common.Api;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class GetAllVendaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapGet("/", HandlerAsync)
        .WithName("Vendas: Get All")
        .WithSummary("Recuperar todas as vendas")
        .WithDescription("Recuperar todas as vendas")
        .WithOrder(5)
        .Produces<Response<Venda?>>();
    private static async Task<IResult> HandlerAsync(IVendasHandler handler,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllVendasRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
