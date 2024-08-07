using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Cliente;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers
{
    public class ClienteHandler(IHttpClientFactory httpClientFactory) : IClienteHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Cliente?>> CreateAsync(CreateClienteRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/clientes", request);
            return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
                ?? new Response<Cliente?>(null, 400, "Falha ao adicionar o cliente");
        }
        public async Task<Response<Cliente?>> DeleteAsync(DeleteClienteRequest request)
        {
            var result = await _client.DeleteAsync($"v1/clientes/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
                ?? new Response<Cliente?>(null, 400, "Falha ao exluir o cliente");
        }
        public async Task<Response<Cliente?>> UpdateAsync(UpdateClienteRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/clientes/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Cliente?>>()
                ?? new Response<Cliente?>(null, 400, "Falha ao atualizar os dados do cliente");
        }
        public async Task<Response<Cliente?>> GetByIdAsync(GetClienteByIdRequest request)
        =>
            await _client.GetFromJsonAsync<Response<Cliente?>>($"v1/clientes/{request.Id}")
                ?? new Response<Cliente?>(null, 400, "Não foi possível obter o cliente");
       
        public async Task<PagedResponse<List<Cliente?>>> GetAllAsync(GetAllClientesRequest request)
        =>
            await _client.GetFromJsonAsync<PagedResponse<List<Cliente?>>>("v1/clientes")
            ?? new PagedResponse<List<Cliente?>>(null, 400, "Não foi possivel obter os clientes");


    }

       

       
    
}
