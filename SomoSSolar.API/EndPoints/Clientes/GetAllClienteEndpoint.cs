using Microsoft.AspNetCore.Mvc;
using SomoSSolar.API.Common.Api;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Clientes;

public class GetAllClienteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
   => app.MapGet("/", HandlerAsync)
        .WithName("Clientes: Get All")
        .WithSummary("Recupera todos os clientes")
        .WithDescription("Recupera todos os cliente")
        .WithOrder(5)
        .Produces<PagedResponse<List<Cliente>?>>();

    private static async Task<IResult>HandlerAsync(IClienteHandler hanlder,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllClientesRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await hanlder.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
