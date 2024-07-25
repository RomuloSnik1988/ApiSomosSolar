using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Equipamentos;

public class GetEquipamentoByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandlerAsync)
        .WithName("Equipamentos: Get By Id")
        .WithSummary("Buscar Equipamento por Id")
        .WithDescription("Buscar Esquipamento por Id")
        .WithOrder(4)
        .Produces<Response<Equipamento?>>();
    private static async Task<IResult> HandlerAsync(IEquipamentosHandler handler, int id)
    {
        var request = new GetEquipamentoByIdRequest { Id = id };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
