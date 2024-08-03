using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class GetByClienteIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("2/{id}", HandlerAsync)
        .WithName("Enderecos: Get By ClienteID")
        .WithSummary("Buscar endereços pelo id do cliente")
        .WithDescription("Buscar endereço pelo id do cliente")
        .WithOrder(7)
        .Produces<Response<List<Endereco>?>>();
    private static async Task<IResult> HandlerAsync(IEnderecoHandler handler, int id)
    {
        var request = new GetEnderecoByClienteIdRequest { Id = id };

        var result = await handler.GetEnderecoByClienteId(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
