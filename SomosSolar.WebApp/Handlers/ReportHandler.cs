using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Models.Reports;
using SomoSSolar.Core.Requests.Reports;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers;

public class ReportHandler(IHttpClientFactory httpClientFactory) : IReportHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<TotalClientes>?> GetTotalClientesAsync(GetTotalClientesRequest request)
    {
        return await _client.GetFromJsonAsync<Response<TotalClientes>?>($"v1/reports/totalclientes")
             ?? new Response<TotalClientes>(null, 400, "Não foi possível obter os dados");
    }

    public async Task<Response<TotalInstalacoes>?> GetTotalInstalacaoAsync(GetTotalInstalacoesRequest request)
    {
        return await _client.GetFromJsonAsync<Response<TotalInstalacoes>?>("v1/reports/totalinstalacoes")
            ?? new Response<TotalInstalacoes>(null, 400, "Não foi possível obter dados");
    }

    public async Task<Response<TotalInvesores>?> GetTotalInversoresAsync(GetTotalInvesoresRequest request)
    {
        return await _client.GetFromJsonAsync<Response<TotalInvesores>?>("v1/reports/totalinversores")
            ?? new Response<TotalInvesores>(null, 400, "Não foi possível obter dados");
    }

    public async Task<Response<TotalPainesVenda>?> GetTotalPaineisVendaAsync(GetTotalPaineisVendasRequest request)
    {
        return await _client.GetFromJsonAsync < Response<TotalPainesVenda>?>($"v1/reports/totalplacas")
            ?? new Response<TotalPainesVenda>(null, 400, "Não foi possível obter os dados");

    }
}
