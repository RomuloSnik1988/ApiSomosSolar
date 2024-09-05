using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Features;
using MudBlazor.Services;
using SomosSolar.WebApp;
using SomosSolar.WebApp.Handlers;
using SomosSolar.WebApp.Security;
using SomoSSolar.Core.Handlers;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Handlers.Vendas;
using System.Globalization;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


// Configurar tamanho máximo de upload de arquivos
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800; // 50MB
});

Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CookieHandler>();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)
x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();

builder.Services.AddHttpClient(Configuration.HttpClientName, opt =>
{
    opt.BaseAddress = new Uri(Configuration.BackendUrl);
    opt.Timeout = TimeSpan.FromMinutes(5);
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<IAccountHandler, AccountHandler>();
builder.Services.AddTransient<IClienteHandler, ClienteHandler>();
builder.Services.AddTransient<IEnderecoHandler, EnderecoHandler>();
builder.Services.AddTransient<IEquipamentoHandler, EquipamentoHandler>();
builder.Services.AddTransient<IInstacacaoHandler, InstacacaoHandler>();
builder.Services.AddTransient<IVendasHandler, VendaHandler>();
builder.Services.AddTransient<IReportHandler, ReportHandler>();

builder.Services.AddLocalization();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");


await builder.Build().RunAsync();
