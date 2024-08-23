using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Reports;

public class TotalClientesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/totalclientes", HandlerAsync)
        .Produces<Response<TotalClientes>?>();
    public static async Task<IResult>HandlerAsync(IReportHandler handler)
    {
        var request = new GetTotalClientesRequest();

        var result = await handler.GetTotalClientesAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);

    }
}
