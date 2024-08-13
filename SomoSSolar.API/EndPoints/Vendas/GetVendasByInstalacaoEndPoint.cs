using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class GetVendasByInstalacaoEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("3/{id}", HandlerAsync)
        .WithName("Vendas: Get Vendas By Id Instalacao")
        .WithSummary("Buscar a Venda da instalação com id")
        .WithDescription("Buscar a Venda da instalação com id")
        .WithOrder(7)
        .Produces<Response<Venda?>>();
    public static async Task<IResult> HandlerAsync(IVendasHandler handler, int id)
    {
        var request = new GetVendasByInstalacaoRequest { Id = id };

        var result = await handler.GetVendasAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }

}
