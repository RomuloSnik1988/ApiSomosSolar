using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
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
    public List<Venda> Vendas { get; set; } = new List<Venda?>();
    public string NomeCliente => Cliente?.Nome ?? "Cliente não encontrado";
    public Venda? Venda { get; set; }
    public Endereco Endereco { get; set; } = null!;
    public GetVendasByInstalacaoRequest VendaInstalcao { get; set; } = new();
    #endregion

    #region Parameter
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion

    #region Services
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
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    #endregion

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
            var response = await InstalacaoHanler.GetByIdAsync(request);
            if (response.IsSuccess && response.Data is not null)
            {
                var instalacao = response.Data;
                InputModelInstalacao.Id = instalacao.Id;

                //Cliente = instalacao.Cliente;
                var enderecoRequest = new GetEnderecoByIdRequest
                {
                    Id = instalacao.EnderecoId
                };
                await GetClienteById(instalacao.EnderecoId);
                await GetVendasAsync(instalacao.Id);

                var enderecoResponse = await EnderecoHandler.GetByIdAsync(enderecoRequest);
                if (enderecoResponse.IsSuccess && enderecoResponse.Data is not null)
                {
                    Endereco = enderecoResponse.Data;
                }
                

            }
        }
        catch (Exception ex)
        {

            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
  
    }

    #endregion

    #region Methods
    public async Task GetVendasAsync(int instalacaoId)
    {
        try
        {
            var request = new GetVendasByInstalacaoRequest { Id = instalacaoId };
            var response = await VendasHandler.GetVendasAsync(request);

            if(response.IsSuccess && response.Data is not null)
            {
                Vendas = response.Data.Where(venda => venda != null).ToList()!;
            }
            else
            {
                Snackbar.Add("Vendas não localizas", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    public async Task GetClienteById(int enderecoid)
    {
        try
        {
            var request = new GetClienteByIdRequest { Id = enderecoid };
            var response = await ClienteHandler.GetByIdAsync(request);
            if(response.IsSuccess && response?.Data is not null)
            {
                Cliente = response.Data;
            }
            else
            {
                Snackbar.Add("Cliente não encontrado", Severity.Error);
            }
        }
        catch 
        {
            Snackbar.Add("Erro ao buscar o cliente", Severity.Error);
        }
    }
    
    #endregion
    public void OpenModal()
    {

        // Verifique se o InstalacaoId está correto antes de abrir o modal
        Console.WriteLine($"InstalacaoId: {InputModelInstalacao.Id}");

        var parameters = new DialogParameters
        {
            {"InstalacaoId", InputModelInstalacao.Id },

        };
        DialogService.Show<AddEquipamentosModal>("Adicionar Equipamentos", parameters, new DialogOptions
        {
            CloseOnEscapeKey = true
        });
    }
}
