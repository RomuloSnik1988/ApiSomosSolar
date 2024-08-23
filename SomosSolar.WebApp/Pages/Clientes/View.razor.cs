using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomosSolar.WebApp.Handlers;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Requests.Vendas;

namespace SomosSolar.WebApp.Pages.Clientes;

public class ViewClientePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public Cliente Cliente { get; set; } = null!;
    public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public List<Instalacao> Instacoes { get; set; } = new List<Instalacao>();
    public List<Venda> Vendas { get; set; } = new List<Venda>();
    public GetClienteByIdRequest? InputModel { get; set; }
    public UpdateClienteRequest? EnderecoInputModel { get; set; }
    #endregion
    #region Parameter
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IClienteHandler Handler { get; set; } = null!;
    [Inject]
    IEnderecoHandler EnderecoHandler { get; set; } = null!;
    [Inject]
    IInstacacaoHandler InstalacaoHandler { get; set; } = null!;
    [Inject]
    IVendasHandler VendasHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    #endregion

    #region Override
    protected override async Task OnInitializedAsync()
    {
        if(!int.TryParse(Id, out var clienteid))
        {
            Snackbar.Add("Parametro Inválido", Severity.Error);
        }
        IsBusy = true;
        try
        {
            var resquest = new GetClienteByIdRequest { Id = clienteid };
            var response = await Handler.GetByIdAsync(resquest);

            if(response.IsSuccess && response.Data is not null)
            {
                InputModel = new GetClienteByIdRequest
                {
                    Id = clienteid,
                };
                Cliente = response.Data;
                await GetEnderecosById(clienteid);
            }
        }
        catch 
        {
            Snackbar.Add("Cliente não encontrado", Severity.Error);
        }
        finally { IsBusy = false; }
    }

    #endregion

    #region Methods
    public async Task GetEnderecosById(int clienteid)
    {
        try
        {
            var request = new GetEnderecoByClienteIdRequest { Id = clienteid };
            var response = await EnderecoHandler.GetByClienteIdAsync(request);

            if(response.IsSuccess && response.Data is not null)
            {
                Enderecos = response.Data.Where(endereco => endereco != null).ToList()!;
                
                foreach (var endereco in Enderecos)
                {
                    endereco.Instalacoes = await CarregarInstalacoesPorEnderecoId(endereco.Id);

                    foreach (var instalcao in endereco.Instalacoes)
                    {
                        if(instalcao != null)
                        {
                            var instalacaoId = instalcao.Id;

                            instalcao.Vendas = await CarregarVendasPorInstalacaoId(instalacaoId);

                            //Verificar o ID da instalação
                            //Snackbar.Add($"Instalacao ID: {instalacaoId}" , Severity.Info);
                        }
                    }
                }
                
            }
            else
            {
                Snackbar.Add("Endereço não encontrado", Severity.Error);
            }
        }
        catch 
        {
            Snackbar.Add("Erro ao buscar endereço", Severity.Error);
        }
    }
    public async Task<List<Instalacao>> CarregarInstalacoesPorEnderecoId(int enderecoId)
    {
        var request = new GetInstacalaoByEnderecoRequest { Id = enderecoId };
        var response = await InstalacaoHandler.GetByEnderecoAsync(request);

        return response.IsSuccess ? response.Data : new List<Instalacao>();

    }
    public async Task<List<Venda>> CarregarVendasPorInstalacaoId(int instalacaoId)
    {
        var request = new GetVendasByInstalacaoRequest { Id = instalacaoId };
        var response = await VendasHandler.GetVendasAsync(request);

        return response.IsSuccess ? response.Data : new List<Venda?>();
    }
    #endregion
    public async Task AdicionarEndereco(int clienteid)
    {
        NavigationManager.NavigateTo($"/enderecos/adicionar/{clienteid}");
    }
}
