using Microsoft.AspNetCore.Mvc;
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
        .DisableAntiforgery()
        .Produces<Response<Equipamento?>>();

    // Validação do ModelState

    private static async Task<IResult>HandleAsync(IEquipamentoHandler handler,[FromForm]CreateEquipamentosRequest request, IFormFile imageFile)
    {
        
        var result = await handler.CreateAsync(imageFile, request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}
