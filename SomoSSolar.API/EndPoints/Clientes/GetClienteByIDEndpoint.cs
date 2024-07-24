using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Clientes;

public class GetClienteByIDEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapGet("/{id}", HandlerAsync)
        .WithName("Clientes: Get By Id")
        .WithSummary("Buscar um cliente por id")
        .WithDescription("Buscar um cliente por id")
        .WithOrder(4)
        .Produces<Response<Cliente?>>();

    private static async Task<IResult>HandlerAsync(IClienteHandler handler, int id)
    {
        var request = new GetClienteByIdRequest
        {
            Id = id
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
