using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Vendas;

public class CreateVendaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandlerAsync)
        .WithName("Vendas: Create")
        .WithSummary("Incluir uma nova venda")
        .WithDescription("Incluir uma nova venda")
        .WithOrder(1)
        .Produces<Response<Venda?>>();
    private static async Task<IResult>HandlerAsync(IVendasHendler hendler, CreateVendaRequest request)
    {
        var result = await hendler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
