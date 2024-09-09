using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
    public Cliente Cliente { get; set; } = null!;
    public UpdateInstalacaoRequest InputModelInstalacao { get; set; } = new();
    public List<Venda> Vendas { get; set; } = new List<Venda>();
    public Endereco Endereco { get; set; } = null!;

    public string ApiBaseUrl = Configuration.BackendUrl + ("/"); // URL base da API para imagens

    #endregion

    #region Parameter
    [Parameter]
    public string Id { get; set; } = string.Empty;
    [Parameter]
    public int InstalacaoId { get; set; }
    [Parameter]
    public int VendaId { get; set; }

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
                    Id = instalacao.EnderecoId,
                };
                await GetVendasAsync(instalacao.Id);

                var enderecoResponse = await EnderecoHandler.GetByIdAsync(enderecoRequest);
                if (enderecoResponse.IsSuccess && enderecoResponse.Data is not null)
                {
                    Endereco = enderecoResponse.Data;

                    if (Endereco.ClienteId > 0)
                    {
                        await GetClienteById(Endereco.ClienteId);
                    }
                    else
                    {
                        Snackbar.Add("Cliente Id não encontrado no endereço", Severity.Warning);
                    }
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
    public async Task GetClienteById(int clienteid)
    {
        try
        {
            var request = new GetClienteByIdRequest { Id = clienteid };
            var response = await ClienteHandler.GetByIdAsync(request);
            if(response.IsSuccess && response?.Data is not null)
            {
                Cliente = response.Data;
            }
            else
            {
                Snackbar.Add("Cliente não encontrado", Severity.Error);
                Console.WriteLine($"ClienteID:{ Cliente.Id}");
            }
        }
        catch 
        {
            Snackbar.Add("Erro ao buscar o cliente", Severity.Error);
        }
    }
    
    #endregion
    public async void OpenModal()
    {

        //// Verifique se o InstalacaoId está correto antes de abrir o modal
        //Console.WriteLine($"VendaId: {InputModelInstalacao.Id}");

        var parameters = new DialogParameters
        {
            {"InstalacaoId", InputModelInstalacao.Id },

        };

        var dialog = DialogService.Show<AddEquipamentosModal>("Adicionar Equipamentos", parameters, new DialogOptions
        {
            CloseOnEscapeKey = true,
        });

        var result = await dialog.Result;

        if (result.Data is bool sucesso && sucesso)
        {
            //Snackbar.Add("Dados dados Atualizados com Sucesso", Severity.Success);
            await UpdateGridAsync();
        }
        else
            Snackbar.Add("Atualização cancelada", Severity.Info);
    }

    public async Task OpenModalEdit(int id)
    {

        //// Verifique se o VendaId está correto antes de abrir o modal
        //Console.WriteLine($"VendaId: {InputModelInstalacao.Id}");

        var parameters = new DialogParameters
        {
            {"VendaId",id},

        };

        var dialog = DialogService.Show<EditEquipamentosModal>("Editar Quantidade de Equipamentos", parameters, new DialogOptions
        {
            CloseOnEscapeKey = true,
        });

        var result = await dialog.Result;

        if (result.Data is bool sucesso && sucesso)
        {
            //Snackbar.Add("Dados dados Atualizados com Sucesso", Severity.Success);
            await UpdateGridAsync();
        }
        else
            Snackbar.Add("Atualização cancelada", Severity.Info);

    }

    public async Task UpdateGridAsync()
    {
        try
        {
            await GetVendasAsync(InputModelInstalacao.Id);
            Console.WriteLine($"InstalacaoId: {InputModelInstalacao.Id}");

            if (Vendas != null && Vendas.Any())
            {
                Snackbar.Add("Dados Atualizados com sucesso!", Severity.Success);
            }
            else
            {
                Snackbar.Add("Nenhum Dado encontrado", Severity.Warning);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao atualizar os dados:{ex.Message}");
        }
        finally { StateHasChanged(); }
    }

    public async Task OnDeleteButtonClikedAsync(int id, int quantidade, string modelo)
    {
        var result = await DialogService.ShowMessageBox("Atenção", $"Ao prosseguir {quantidade}" +
            $" {modelo} será excuido. Essa é uma ação irreversível! Deseja Continuar?",
            yesText: "EXCLUIR",
            cancelText: "CANCELAR");

        if (result is true)
            await OnDeleteAsync(id, quantidade,modelo);

        StateHasChanged();
    }

    public async Task OnDeleteAsync(int id, int quantidade,string modelo)
    {
        try
        {
            await VendasHandler.DeleteAsync(new DeleteVendaRequest { Id = id });
            Vendas.RemoveAll(x => x.Id == id);
            Snackbar.Add($"{quantidade} {modelo}, excluído", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }

}
