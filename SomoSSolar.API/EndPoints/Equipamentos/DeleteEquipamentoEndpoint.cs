using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Equipamentos;

public class DeleteEquipamentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
  => app.MapDelete("/{id}", HandleAsync)
        .WithName("Equipamentos: Delete")
        .WithSummary("Excluir um equipamento")
        .WithDescription("Excluir um equipamento")
        .WithOrder(3)
        .Produces<Response<Equipamento?>>();
    private static async Task<IResult> HandleAsync(IEquipamentoHandler handler, int id)
    {
        var request = new DeleteEquipamentoRequest { Id = id };

        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
