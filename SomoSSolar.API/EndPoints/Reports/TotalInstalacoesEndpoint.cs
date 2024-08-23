using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Reports;

public class TotalInstalacoesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/totalinstalacoes", HandlerAsync)
        .Produces<Response<TotalInstalacoes>?>();
    public static async Task<IResult>HandlerAsync(IReportHandler handler)
    {
        var request = new GetTotalInstalacoesRequest();
        var result = await handler.GetTotalInstalacaoAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);

    }
}
