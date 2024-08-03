using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class DeleteEnderecoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Endereços: Delete")
        .WithSummary("Exluir um endereço")
        .WithDescription("Excluir um endereço")
        .WithOrder(3)
        .Produces<Response<Endereco?>>();

    private static async Task<IResult>HandlerAsync(IEnderecoHandler handler, int id)
    {
        var request = new DeleteEnderecoRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
