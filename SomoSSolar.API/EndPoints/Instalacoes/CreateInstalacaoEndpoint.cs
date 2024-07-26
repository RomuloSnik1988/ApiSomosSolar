using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class CreateInstalacaoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapPost("/", HandlerAsync)
        .WithName("Instalações: Create")
        .WithSummary("Incluir uma nova instalação")
        .WithDescription("Incluir uma nova instalação")
        .WithOrder(1)
        .Produces<Response<Instalacao?>>();
    private static async Task<IResult>HandlerAsync(IInstacacaoHandler handler, CreateInstalacaoRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
