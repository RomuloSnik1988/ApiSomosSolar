using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Endereco;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers
{
    public class EnderecoHandler(IHttpClientFactory httpClientFactory) : IEnderecoHandler
    {
        private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

        public async Task<Response<Endereco?>> CreateAsync(CreateEnderecoRequest request)
        {
            var result = await _client.PostAsJsonAsync("v1/enderecos", request);
            return await result.Content.ReadFromJsonAsync<Response<Endereco?>>()
                ?? new Response<Endereco?>(null, 400, "Falha ao adicionar o endereço");
        }

        public async Task<Response<Endereco?>> DeleteAsync(DeleteEnderecoRequest request)
        {
            var result = await _client.DeleteAsync($"v1/enderecos/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Endereco?>>()
                ?? new Response<Endereco?>(null, 400, "Falha ao exluir o endereço");
        }
        public async Task<Response<Endereco?>> UpdateAsync(UpdateEnderecoRequest request)
        {
            var result = await _client.PutAsJsonAsync($"v1/enderecos/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Endereco?>>()
                ?? new Response<Endereco?>(null, 400, "Falha ao atualizar o endereço");
        }
        public async Task<Response<Endereco?>> GetByIdAsync(GetEnderecoByIdRequest request)
           =>
           await _client.GetFromJsonAsync<Response<Endereco?>>($"v1/enderecos/{request.Id}")
               ?? new Response<Endereco?>(null, 400, "Não foi possível obter o endereço");

        public async Task<PagedResponse<List<Endereco?>>> GetAllAsync(GetAllEnderecosRequest request)
         =>
            await _client.GetFromJsonAsync<PagedResponse<List<Endereco?>>>("v1/enderecos")
            ?? new PagedResponse<List<Endereco?>>(null, 400, "Não foi possivel obter os clientes");

        public async Task<Response<List<Endereco?>>> GetEnderecoByClienteAsync(GetEnderecosClienteRequest request)
        =>
            await _client.GetFromJsonAsync<Response<List<Endereco?>>>($"v1/enderecos/{request.Id}")
            ?? new Response<List<Endereco?>>(null, 400, "Não foi possivel obter os clientes");

        public async Task<Response<List<Endereco?>>> GetEnderecoByClienteId(GetEnderecoByClienteIdRequest request)
      =>
            await _client.GetFromJsonAsync<Response<List<Endereco?>>>($"v1/enderecos/{request.Id}")
            ?? new Response<List<Endereco?>>(null, 400, "Não foi possível obter os endereços");
    }
}
