using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class UpdateVendaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapPut("/{id}", HandlerAsync)
        .WithName("Vendas: Update")
        .WithSummary("Atualizar uma venda")
        .WithDescription("Atualizar uma venda")
        .WithOrder(2)
        .Produces<Response<Venda?>>();
    private static async Task<IResult>HandlerAsync(IVendasHendler handler, UpdateVendaRequest request, int id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
