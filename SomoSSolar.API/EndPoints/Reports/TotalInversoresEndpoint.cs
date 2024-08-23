using SomoSSolar.API.Common.Api;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;

namespace SomoSSolar.API.EndPoints.Reports;

public class TotalInversoresEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/totalinversores", HandlerAsync)
        .Produces<Response<TotalInvesores>?>();
    public static async Task<IResult>HandlerAsync(IReportHandler hanlder)
    {
        var request = new GetTotalInvesoresRequest();
        var result = await hanlder.GetTotalInversoresAsync(request);    
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
