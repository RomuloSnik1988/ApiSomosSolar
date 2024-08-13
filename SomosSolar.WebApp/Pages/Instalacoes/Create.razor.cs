using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Requests.Instalacoes;

namespace SomosSolar.WebApp.Pages.Instalacoes;

public partial class CreateInstacalaoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateInstalacaoRequest InputModel { get; set; } = new();
    public List<Cliente> Clientes { get; set; } = [];
    public List<Endereco> Enderecos { get; set; } = [];
    #endregion
    #region Services
    [Inject]
    public IInstacacaoHandler Handler { get; set; } = null!;
    [Inject]
    public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject]
    public IEnderecoHandler EnderecoHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion
    #region Override
    protected override async Task OnInitializedAsync()
    {
        await GetClientesAsync();
        await GetEnderecosAsync();
    }
    #endregion
    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/addEquipamentos/");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
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
                //InputModel.ClienteId = Clientes.FirstOrDefault()?.Id ?? 0;
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
                InputModel.EnderecoId = Enderecos.FirstOrDefault()?.Id ?? 0;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    #endregion
}
