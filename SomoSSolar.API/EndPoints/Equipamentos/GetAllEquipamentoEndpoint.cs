using Microsoft.AspNetCore.Mvc;
using SomoSSolar.API.Common.Api;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Equipamentos;

public class GetAllEquipamentoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/", HandleAsync)
        .WithName("Equipamentos: Get All")
        .WithSummary("Recupera todos os equipamentos")
        .WithDescription("Recupera todos os equipamentos")
        .WithOrder(5)
        .Produces<PagedResponse<List<Equipamento>?>>();
    private static async Task<IResult> HandleAsync(IEquipamentoHandler handler,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllEquipamentosRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
