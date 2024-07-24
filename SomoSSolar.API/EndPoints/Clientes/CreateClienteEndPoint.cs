using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Cliente;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Clientes;

public class CreateClienteEndPoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapPost("/", HandleAsync)
        .WithName("Clientes: Create")
        .WithSummary("Incluir um novo cliente")
        .WithDescription("Incluir um novo cliente")
        .WithOrder(1)
        .Produces<Response<Cliente?>>();

    private static async Task<IResult>HandleAsync(IClienteHandler handler, CreateClienteRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
