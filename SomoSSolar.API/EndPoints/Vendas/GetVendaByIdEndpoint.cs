using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class GetVendaByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapGet("/{id}", HandlerAsync)
        .WithName("Vendas: Get By Id")
        .WithSummary("Buscar venda por id")
        .WithDescription("Buscar venda por id")
        .WithOrder(4)
        .Produces<Response<Venda?>>();
    private static async Task<IResult>HandlerAsync(IVendasHandler handler, int id)
    {
        var request = new GetVendaByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
