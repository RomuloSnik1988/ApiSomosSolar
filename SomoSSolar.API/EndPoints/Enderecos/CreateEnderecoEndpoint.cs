using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Endereco;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Enderecos;

public class CreateEnderecoEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapPost("/", HandlerAsync)
        .WithName("Endereços: Create")
        .WithSummary("Adicionar um novo Endereço")
        .WithDescription("Adicionar um novo Endereço")
        .WithOrder(1)
        .Produces<Response<Endereco?>>();

    private static async Task<IResult>HandlerAsync(IEnderecoHandler handler, CreateEnderecoRequest request)
    {
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
