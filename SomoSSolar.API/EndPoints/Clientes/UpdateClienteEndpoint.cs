using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Clientes;

public class UpdateClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Clientes: Update")
        .WithSummary("Atualiza um cliente")
        .WithDescription("Atualiza um cliente")
        .WithOrder(2)
        .Produces<Response<Cliente?>>();

    private static async Task<IResult>HandlerAsync(IClienteHandler handler, UpdateClienteRequest request, int id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ?TypedResults.Ok(result)
            :TypedResults.BadRequest(result);
    }
}
