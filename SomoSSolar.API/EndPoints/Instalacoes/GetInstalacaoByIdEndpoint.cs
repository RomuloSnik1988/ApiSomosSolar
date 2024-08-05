using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class GetInstalacaoByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapGet("/{id}", HandlerAsync)
        .WithName("Instalações: Get By Id")
        .WithSummary("Buscar uma instalação com id")
        .WithDescription("Buscar uma instalação por id")
        .WithOrder(4)
        .Produces<Response<Instalacao?>>();
    private static async Task<IResult> HandlerAsync(IInstacacaoHandler handler, int id)
    {
        var request = new GetInstalacaoByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
