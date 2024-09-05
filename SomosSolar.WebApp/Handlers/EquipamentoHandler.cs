using Microsoft.AspNetCore.Http;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Responses;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SomosSolar.WebApp.Handlers;

public class EquipamentoHandler(IHttpClientFactory httpClientFactory) : IEquipamentoHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<Response<Equipamento?>> CreateAsync(IFormFile imageFile, CreateEquipamentosRequest request)
    {

        using var content = new MultipartFormDataContent();

        // Adicionar os campos diretamente ao MultipartFormDataContent
        content.Add(new StringContent(request.Tipo.ToString()), "tipo");
        content.Add(new StringContent(request.Fornecedor), "fornecedor");
        content.Add(new StringContent(request.Marca), "marca");
        content.Add(new StringContent(request.Modelo), "modelo");
        content.Add(new StringContent(request.Potencia.ToString()), "potencia");
        content.Add(new StringContent(request.PotenciaMaxima), "potenciaMaxima");
        content.Add(new StringContent(request.Peso), "peso");
        content.Add(new StringContent(request.Tamanho), "tamanho");

        if (imageFile != null && imageFile.Length > 0)
        {
            try
            {
                var stream = imageFile.OpenReadStream();
                var fileContent = new StreamContent(stream);

                //Console.WriteLine($"Nome do Arquivo: {imageFile.FileName}");
                //Console.WriteLine($"Tipo do Arquivo: {imageFile.ContentType}");
                //Console.WriteLine($"Tamanho do Arquivo: {imageFile.Length}");

                fileContent.Headers.ContentType = new MediaTypeHeaderValue(imageFile.ContentType);
                content.Add(fileContent, "imageFile", imageFile.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar o arquivo de imagem: {ex.Message}");
                return new Response<Equipamento?>(null, 500, "Erro ao processar o arquivo de imagem");
            }
        }

        var result = await _client.PostAsync("v1/equipamentos", content);
        return await result.Content.ReadFromJsonAsync<Response<Equipamento?>>()
        ?? new Response<Equipamento?>(null, 400, "Falha ao adicionar o equipamento");

    }

    //public async Task<Response<Equipamento?>> CreateAsync(CreateEquipamentosRequest request)
    //{
    //    var result = await _client.PostAsJsonAsync("v1/equipamentos", request);
    //    return await result.Content.ReadFromJsonAsync<Response<Equipamento?>>()
    //        ?? new Response<Equipamento?>(null, 400, "Falha ao adicionar o equipamento");
    //}

    public async Task<Response<Equipamento?>> DeleteAsync(DeleteEquipamentoRequest request)
    {
        var result = await _client.DeleteAsync($"v1/equipamentos/{request.Id}");
        return await result.Content.ReadFromJsonAsync<Response<Equipamento?>>()
            ?? new Response<Equipamento?>(null, 400, "Falha ao exluir o equipamento");
    }
    public async Task<Response<Equipamento?>> UpdateAsync(UpdateEquipamentoRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/equipamentos/{request.Id}", request);
        return await result.Content.ReadFromJsonAsync<Response<Equipamento?>>()
            ?? new Response<Equipamento?>(null, 400, "Falha ao atualizar o equipamento");
    }
    public async Task<Response<Equipamento?>> GetByIdAsync(GetEquipamentoByIdRequest request)
   => await _client.GetFromJsonAsync<Response<Equipamento?>>($"v1/equipamentos/{request.Id}")
        ?? new Response<Equipamento?>(null, 400, "Não foi possível obter o equipamento");

    public async Task<PagedResponse<List<Equipamento?>>> GetAllAsync(GetAllEquipamentosRequest request)
    => await _client.GetFromJsonAsync<PagedResponse<List<Equipamento>?>>("v1/equipamentos")
        ?? new PagedResponse<List<Equipamento?>>(null, 400, "não foi possível obter os equipamentos");

    
}
