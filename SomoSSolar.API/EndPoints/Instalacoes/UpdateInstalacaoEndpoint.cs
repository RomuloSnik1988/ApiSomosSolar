using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class UpdateInstalacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Instalação: Update")
        .WithSummary("Atualizar uma instalação")
        .WithDescription("Atualizar uma instalaçao")
        .WithOrder(2)
        .Produces<Response<Instalacao?>>();
    private static async Task<IResult> HandlerAsync(IInstacacaoHandler handler,UpdateInstalacaoRequest request,  int id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
