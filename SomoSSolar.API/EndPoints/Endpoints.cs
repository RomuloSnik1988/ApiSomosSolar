using SomoSSolar.API.Common.Api;
using SomoSSolar.API.EndPoints.Clientes;
using SomoSSolar.API.EndPoints.Enderecos;
using SomoSSolar.API.EndPoints.Equipamentos;
using SomoSSolar.API.EndPoints.Identity;
using SomoSSolar.API.EndPoints.Instalacoes;
using SomoSSolar.API.EndPoints.Reports;
using SomoSSolar.API.EndPoints.Vendas;
using SomoSSolar.API.Models;
using SomoSSolar.Core.Requests.Reports;

namespace SomoSSolar.API.EndPoints;

public static class Endpoints
{
    public static void MapEndpoints (this WebApplication app) 
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Helth Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/clientes")
            .WithTags("Clientes")
            .RequireAuthorization()
            .MapEndpoint<CreateClienteEndPoint>()
            .MapEndpoint<UpdateClienteEndpoint>()
            .MapEndpoint<DeleteClienteEndpoint>()
            .MapEndpoint<GetClienteByIDEndpoint>()
            .MapEndpoint<GetAllClienteEndpoint>();

        endpoints.MapGroup("v1/enderecos")
            .WithTags("Endereços")
            .RequireAuthorization()
            .MapEndpoint<CreateEnderecoEndpoint>()
            .MapEndpoint<UpdateEnderecoEndpoint>()
            .MapEndpoint<DeleteEnderecoEndpoint>()
            .MapEndpoint<GetEnderecoByIdEndpoint>()
            .MapEndpoint<GetAllEnderecoEndpoint>()
            .MapEndpoint<GetByClienteIdEndpoint>();

        endpoints.MapGroup("v1/equipamentos")
            .WithTags("Equipamentos")
            .RequireAuthorization()
            .MapEndpoint<CreateEquipamentoEndpoint>()
            .MapEndpoint<UpdateEquipamentoEndpoint>()
            .MapEndpoint<DeleteEquipamentoEndpoint>()
            .MapEndpoint<GetEquipamentoByIdEndpoint>()
            .MapEndpoint<GetAllEquipamentoEndpoint>();

        endpoints.MapGroup("v1/instalacoes")
            .WithTags("Instalações")
            .RequireAuthorization()
            .MapEndpoint<CreateInstalacaoEndpoint>()
            .MapEndpoint<UpdateInstalacaoEndpoint>()
            .MapEndpoint<DeleteInstalacaoEndpoint>()
            .MapEndpoint<GetInstalacaoByIdEndpoint>()
            .MapEndpoint<GetAllInstalacoesEndpoint>()
            .MapEndpoint<GetInstalacaoByEnderecoEndpoint>();

        endpoints.MapGroup("v1/vendas")
            .WithTags("Vendas")
            .RequireAuthorization()
            .MapEndpoint<CreateVendaEndpoint>()
            .MapEndpoint<UpdateVendaEndpoint>()
            .MapEndpoint<DeleteVendaEndpoint>()
            .MapEndpoint<GetVendaByIdEndpoint>()
            .MapEndpoint<GetAllVendaEndpoint>()
            .MapEndpoint<GetVendasByInstalacaoEndPoint>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<LogoutEndpoint>()
            .MapEndpoint<GetRolesEndpoint>();

        endpoints.MapGroup("v1/reports")
            .WithTags("repors")
            .RequireAuthorization()
            .MapEndpoint<TotalPaineisVendaEndpoint>()
            .MapEndpoint<TotalClientesEndpoint>()
            .MapEndpoint<TotalInversoresEndpoint>()
            .MapEndpoint<TotalInstalacoesEndpoint>()
            .MapEndpoint<TotalVendasMensalEndpoint>();
    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
