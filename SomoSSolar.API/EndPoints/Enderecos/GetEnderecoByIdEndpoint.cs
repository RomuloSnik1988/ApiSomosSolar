using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class GetEnderecoByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandlerAsync)
        .WithName("Endereços: Get By Id")
        .WithSummary("Buscar um endereço por Id")
        .WithDescription("Buscar um endereço por Id")
        .WithOrder(4)
        .Produces<Response<Endereco?>>();
    private static async Task<IResult>HandlerAsync(IEnderecoHandler handler, int id)
    {
        var request = new GetEnderecoByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
