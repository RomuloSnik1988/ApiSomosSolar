using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class DeleteInstalacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Instalações: Delete")
        .WithSummary("Excluir uma instalação")
        .WithDescription("Excluir uma instalação")
        .WithOrder(3)
        .Produces<Response<Instalacao?>>();
    private static async Task<IResult> HandlerAsync(IInstacacaoHandler handler, int id)
    {
        var request = new DeleteInstalacaoRequest { Id = id };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
