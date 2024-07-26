using Microsoft.AspNetCore.Mvc;
using SomoSSolar.API.Common.Api;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Instalacoes;

public class GetAllInstalacoesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/", HandlerAsync)
        .WithName("Instalações: Get All")
        .WithSummary("Recupera todas as instalações")
        .WithDescription("Recupera todas as instalações")
        .WithOrder(5)
        .Produces<Response<Instalacao?>>();

    private static async Task<IResult>HandlerAsync(IInstacacaoHandler handler,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllInstacoesRequest
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
