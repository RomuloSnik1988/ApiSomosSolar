using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class GetEnderecosByClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("1/{Id}", HandlerAsync)
        .WithName("Endereços: Get Endereços do Cliente")
        .WithSummary("Retorna todos os enderços do cliente")
        .WithDescription("Retorna todos os endereços do cliente")
        .WithOrder(6)
        .Produces<Response<List<Endereco>?>>();
    private static async Task<IResult> HandlerAsync(IEnderecoHandler handler, int ClienteId)
    {
        var request = new GetEnderecosClienteRequest { Id = ClienteId };

        var result = await handler.GetEnderecoByClienteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
