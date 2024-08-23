using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Endereco;

namespace SomosSolar.WebApp.Pages.Enderecos;

public class CreateEnderecoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateEnderecoRequest InputModel { get; set; } = new();
    public List<Cliente?> Clientes { get; set; } = [];
    public UpdateClienteRequest InputMCliente { get; set; } = new();
    #endregion
    #region Parameter
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public IEnderecoHandler Handler { get; set; } = null!;
    [Inject]
    public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Override
    protected override async Task OnInitializedAsync()
    {
        await GetClientesByIdAsync();
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
                NavigationManager.NavigateTo("/enderecos");
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
        finally { IsBusy = false; }
        #endregion
    }
    private async Task GetClientesByIdAsync()
    {

        IsBusy = true;
        try
        {
            var request = new GetAllClientesRequest();
            var result = await ClienteHandler.GetAllAsync(request);
            if (result.IsSuccess)
            {
                Clientes = result.Data ?? [];
                InputModel.ClienteId = Clientes.FirstOrDefault()?.Id ?? 0;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
}
