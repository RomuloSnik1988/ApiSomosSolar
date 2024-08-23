using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Reports;

public class TotalPaineisVendaEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/totalplacas", HandlerAsync)
        .Produces<Response<TotalPainesVenda>?>();

    public static async Task<IResult>HandlerAsync(IReportHandler handler)
    {
        var resquest = new GetTotalPaineisVendasRequest();

        var result = await handler.GetTotalPaineisVendaAsync(resquest);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
