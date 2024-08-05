using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Requests.Instalacoes;
using SomoSSolar.Core.Requests.Vendas;

namespace SomosSolar.WebApp.Pages.Instalacoes;

public class SaleInstalacaoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateVendaRequest InputModel { get; set; } = new();
    public Cliente Cliente { get; set; } = null!;
    public List<Instalacao> Instalacoes { get; set; } = [];
    public UpdateInstalacaoRequest InputModelInstalacao { get; set; } = new();
    public List<Equipamento> Equipamentos { get; set; } = [];
    public List<Cliente> Clientes { get; set; } = [];
    public List<Endereco> Enderecos { get; set; } = [];
    #endregion
    #region Parameter
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IInstacacaoHandler InstalacaoHanler { get; set; } = null!;
    [Inject]
    public IVendasHandler VendasHandler { get; set; } = null!;
    [Inject]
    public IEquipamentoHandler EquipamentoHandler { get; set; } = null!;
    [Inject]
    public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject]
    public IEnderecoHandler EnderecoHandler { get; set; } = null!;

    #region Override 
    protected override async Task OnInitializedAsync()
    {
        GetInstalacaoByIdRequest? request = null;
        try
        {
            request = new GetInstalacaoByIdRequest
            {
                Id = int.Parse(Id)
            };
        }
        catch 
        {
            Snackbar.Add("Parametro inválido", Severity.Error);
        }
        if (request is null)
            return;

        IsBusy = true;
        try
        {
            //await GetClientesAsync();
            //await GetEnderecosAsync();

            var response = await InstalacaoHanler.GetByIdAsync(request);
            if (response.IsSuccess && response.Data is not null);
              
        }
        catch (Exception ex)
        {

            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }
    #endregion

    #region Methods
    private async Task GetClientesAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllClientesRequest();
            var result = await ClienteHandler.GetAllAsync(request);
            if (result.IsSuccess)
            {
                Clientes = result.Data ?? [];
                InputModelInstalacao.ClienteId = Clientes.FirstOrDefault()?.Id ?? 0;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task GetEnderecosAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllEnderecosRequest();
            var result = await EnderecoHandler.GetAllAsync(request);
            if (result.IsSuccess)
            {
                Enderecos = result.Data ?? [];
                InputModelInstalacao.EnderecoId = Enderecos.FirstOrDefault()?.Id ?? 0;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    #endregion
}
