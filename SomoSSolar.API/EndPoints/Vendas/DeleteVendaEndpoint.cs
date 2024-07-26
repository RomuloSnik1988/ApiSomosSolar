using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class DeleteVendaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Vendas: Delete")
        .WithSummary("Excluir uma venda")
        .WithDescription("Excluir uma venda")
        .WithOrder(3)
        .Produces<Response<Venda?>>();
    private static async Task<IResult> HandlerAsync(IVendasHendler handler, int id)
    {
        var request = new DeleteVendaRequest
        {
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
