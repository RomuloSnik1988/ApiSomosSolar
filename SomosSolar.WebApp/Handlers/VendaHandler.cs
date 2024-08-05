using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Vendas;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers
{
    public class VendaHandler(IHttpClientFactory httpClientFactory) : IVendasHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Venda?>> CreateAsync(CreateVendaRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/vendas", request);
            return await result.Content.ReadFromJsonAsync<Response<Venda?>>()
                ?? new Response<Venda?>(null, 400, "Falha ao adicionar a venda");
        }
        public async Task<Response<Venda?>> DeleteAsync(DeleteVendaRequest request)
        {
            var result = await _client.DeleteAsync($"v1/vendas/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Venda?>>()
                ?? new Response<Venda?>(null, 400,"Falha ao exluir a venda");
        }
        public async Task<Response<Venda?>> UpdateAsync(UpdateVendaRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/vendas/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Venda?>>()
                ?? new Response<Venda?>(null, 400,"Falha ao atualizar os dados do cliente");
        }
        public async Task<Response<Venda?>> GetByIdAsync(GetVendaByIdRequest request)
        =>
            await _client.GetFromJsonAsync<Response<Venda?>>($"v1/vendas/{request.Id}")
            ?? new Response<Venda?>(null, 400,"Não foi possível obter a venda");
        public async Task<PagedResponse<List<Venda?>>> GetAllAsync(GetAllVendasRequest request)
      =>
            await _client.GetFromJsonAsync<PagedResponse<List<Venda?>>>("v1/vendas")
            ?? new PagedResponse<List<Venda?>>(null, 400,"Não foi possível obter as vendas");
    }
}
