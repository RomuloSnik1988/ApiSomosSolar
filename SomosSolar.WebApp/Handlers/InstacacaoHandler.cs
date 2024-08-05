using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Responses;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers
{
    public class InstacacaoHandler(IHttpClientFactory httpClientFactory) : IInstacacaoHandler
    {
        private readonly HttpClient _cliente = httpClientFactory.CreateClient(Configuration.HttpClientName);
        public async Task<Response<Instalacao?>> CreateAsync(CreateInstalacaoRequest request)
        {
            var result = await _cliente.PostAsJsonAsync("v1/instalacoes", request);
            return await result.Content.ReadFromJsonAsync<Response<Instalacao?>>()
                ?? new Response<Instalacao?>(null, 400, "Falha ao adicionar a instalação");
        }

        public async Task<Response<Instalacao?>> DeleteAsync(DeleteInstalacaoRequest request)
        {
            var result = await _cliente.DeleteAsync($"v1/instalacoes/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Instalacao?>>()
                ?? new Response<Instalacao?>(null, 400, "Falha ao excliur a instalação");

        }
        public async Task<Response<Instalacao?>> UpdateAsync(UpdateInstalacaoRequest request)
        {
            var result = await _cliente.PutAsJsonAsync($"v1/instalacoes/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Instalacao?>>()
                ?? new Response<Instalacao?>(null, 400, "Falha ao atualizar a instalação");
        }
        public async Task<Response<Instalacao?>> GetByIdAsync(GetInstalacaoByIdRequest request)
      => await _cliente.GetFromJsonAsync<Response<Instalacao?>>($"v1/instalacoes/{request.Id}")
            ?? new Response<Instalacao?>(null, 400, "Não foi possível obter o cliente");

        public async Task<PagedResponse<List<Instalacao?>>> GetAllAsync(GetAllInstacoesRequest request)
       => await _cliente.GetFromJsonAsync<PagedResponse<List<Instalacao?>>>("v1/instalacoes")
            ?? new PagedResponse<List<Instalacao?>>(null, 400, "Não foi possível obter as instalações");

       

       
    }
}
