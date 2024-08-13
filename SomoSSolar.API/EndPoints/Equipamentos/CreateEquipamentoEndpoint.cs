using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Equipamentos;

public class CreateEquipamentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandleAsync)
        .WithName("Equipamentos: Create")
        .WithSummary("Incluir um novo equipamento")
        .WithDescription("Incluir um novo equipamento")
        .WithOrder(1)
        .Produces<Response<Equipamento?>>();

    private static async Task<IResult>HandleAsync(IEquipamentoHandler handler, CreateEquipamentosRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
