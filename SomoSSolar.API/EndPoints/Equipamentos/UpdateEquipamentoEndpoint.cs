using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Equipamentos;

public class UpdateEquipamentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPut("/{id}", HandlerAsync)
        .WithName("Equipamentos: Update")
        .WithSummary("Atualiza um equipamento")
        .WithDescription("Atualiza um equipamento")
        .WithOrder(2)
        .Produces<Response<Equipamento?>>();
    private static async Task<IResult>HandlerAsync(IEquipamentosHandler handler,UpdateEquipamentoRequest request, int id)
    {
        request.Id = id;
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
