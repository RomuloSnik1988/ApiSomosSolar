using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class UpdateEnderecoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Endereços: Update")
        .WithSummary("Atualizar um endereço")
        .WithDescription("Atualizar um endereço")
        .WithOrder(2)
        .Produces<Response<Endereco?>>();
    private static async Task<IResult>HandlerAsync(IEnderecosHandler handler, UpdateEnderecoRequest request, int id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
