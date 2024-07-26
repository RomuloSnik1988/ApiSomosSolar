using SomoSSolar.API.Common.Api;
using SomoSSolar.API.EndPoints.Clientes;
using SomoSSolar.API.EndPoints.Enderecos;
using SomoSSolar.API.EndPoints.Equipamentos;
using SomoSSolar.API.EndPoints.Instalacoes;
using SomoSSolar.API.EndPoints.Vendas;

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

        endpoints.MapGroup("v1/enderecos")
            .WithTags("Endereços")
            .MapEndpoint<CreateEnredecoEndpoint>()
            .MapEndpoint<UpdateEnderecoEndpoint>()
            .MapEndpoint<DeleteEnderecoEndpoint>()
            .MapEndpoint<GetEnderecoByIdEndpoint>()
            .MapEndpoint<GetAllEnderecoEndpoint>();

        endpoints.MapGroup("v1/equipamentos")
            .WithTags("Equipamentos")
            .MapEndpoint<CreateEquipamentoEndpoint>()
            .MapEndpoint<UpdateEquipamentoEndpoint>()
            .MapEndpoint<DeleteEquipamentoEndpoint>()
            .MapEndpoint<GetEquipamentoByIdEndpoint>()
            .MapEndpoint<GetAllEquipamentoEndpoint>();

        endpoints.MapGroup("v1/instalacoes")
            .WithTags("Instalações")
            .MapEndpoint<CreateInstalacaoEndpoint>()
            .MapEndpoint<UpdateInstalacaoEndpoint>()
            .MapEndpoint<DeleteInstalacaoEndpoint>()
            .MapEndpoint<GetInstalacaoByIdEndpoint>()
            .MapEndpoint<GetAllInstalacoesEndpoint>();

        endpoints.MapGroup("v1/vendas")
            .WithTags("Vendas")
            .MapEndpoint<CreateVendaEndpoint>()
            .MapEndpoint<UpdateVendaEndpoint>()
            .MapEndpoint<DeleteVendaEndpoint>()
            .MapEndpoint<GetVendaByIdEndpoint>()
            .MapEndpoint<GetAllVendaEndpoint>();
    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
