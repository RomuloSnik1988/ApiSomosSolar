using Microsoft.AspNetCore.Mvc;
using SomoSSolar.API.Common.Api;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class GetAllEnderecoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/", HandlerAsync)
        .WithName("Endereços: Get All")
        .WithSummary("Buscar todos os endereços")
        .WithDescription("Buscar todos os endereços")
        .WithOrder(5)
        .Produces<PagedResponse<List<Endereco>?>>();
    private static async Task<IResult>HandlerAsync(IEnderecosHandler handler,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllEnderecosRequest
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
