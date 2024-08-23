using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Reports;

public class TotalVendasMensalEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/totalvendas-anual", HandlerAsync)
        .Produces<Response<List<GetTotalVendaMensalRequest>?>>();
    public static async Task<IResult>HandlerAsync(IReportHandler handler)
    {
        var request = new GetTotalVendaMensalRequest();
        var result = await handler.GetTotalVendasMensalAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    } 
}
