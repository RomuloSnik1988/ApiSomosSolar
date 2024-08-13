using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class GetInstalacaoByEnderecoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("2/{id}", HandlerAsync)
        .WithName("Instalações: Get By Id Endereço")
        .WithSummary("Buscar instalações por id do endereço")
        .WithDescription("Buscar instalações por id endereço")
        .WithOrder(7)
        .Produces<Response<List<Instalacao>?>>();
    private static async Task<IResult> HandlerAsync(IInstacacaoHandler handler, int id)
    {
        var request = new GetInstacalaoByEnderecoRequest { Id = id };
        var result = await handler.GetByEnderecoAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
