using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SomoSSolar.API.Data;
using SomoSSolar.API.Handlers;
using SomoSSolar.API.Models;
using SomoSSolar.Core;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Handlers.Vendas;

namespace SomoSSolar.API.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }
    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
        builder.Services.AddAuthorization();
    }
    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => {
            x.UseSqlServer(Configuration.ConnectionString);
        });
        builder.Services.AddIdentityCore<User>().AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IClienteHandler, ClienteHandler>();
        builder.Services.AddTransient<IEnderecosHandler, EnderecoHandler>();
        builder.Services.AddTransient<IEquipamentosHandler, EquipamentoHandler>();
        builder.Services.AddTransient<IInstacacaoHandler, InstalacaoHandler>();
        builder.Services.AddTransient<IVendasHendler, VendaHandler>();
    }
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(ApiConfiguration.CorsPolicyName,
                policy => policy.WithOrigins([Configuration.BackendUrl, Configuration.FrontendUrl])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));
    }
}
