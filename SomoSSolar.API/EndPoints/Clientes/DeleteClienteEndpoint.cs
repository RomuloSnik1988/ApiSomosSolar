using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Clientes;

public class DeleteClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapDelete("/{id}", HandlerAsync)
        .WithName("Clientes: Delete")
        .WithSummary("Excluir um cliente")
        .WithDescription("Excluir um cliente")
        .WithOrder(3)
        .Produces<Response<Cliente?>>();

    private static async Task<IResult>HandlerAsync(IClienteHandler handler, int id)
    {
        var request = new DeleteClienteRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ?TypedResults.Ok(result)
            :TypedResults.BadRequest(result);
    }
}
