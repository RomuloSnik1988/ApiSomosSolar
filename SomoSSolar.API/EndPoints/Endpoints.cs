using SomoSSolar.API.Common.Api;
using SomoSSolar.API.EndPoints.Clientes;

namespace SomoSSolar.API.EndPoints;

public static class Endpoints
{
    public static void MapEndpoints (this WebApplication app) 
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("v1/clientes")
            .WithTags("Clientes")
            .MapEndpoint<CreateClienteEndPoint>()
            .MapEndpoint<UpdateClienteEndpoint>()
            .MapEndpoint<DeleteClienteEndpoint>()
            .MapEndpoint<GetClienteByIDEndpoint>()
            .MapEndpoint<GetAllClienteEndpoint>();
    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
