using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Enderecos;

namespace SomosSolar.WebApp.Pages.Enderecos;

public class EditEnderecoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public UpdateEnderecoRequest InputModel { get; set; } = new();
    public List<Cliente> Clientes { get; set; } = [];
    #endregion
    #region Parameters
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEnderecoHandler Handler { get; set; } = null!;
    [Inject]
    public IClienteHandler ClienteHandler { get; set; } = null!;
    #endregion
    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        GetEnderecoByIdRequest? request = null;
        try
        {
            request = new GetEnderecoByIdRequest
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
            await GetClientesAsync();

            var response = await Handler.GetByIdAsync(request);
            if (response.IsSuccess && response.Data is not null)
                InputModel = new UpdateEnderecoRequest
                {
                    Id = response.Data.Id,
                    Lagradouro = response.Data.Lagradouro,
                    Bairro = response.Data.Bairro,
                    Numero = response.Data.Numero,
                    Complemento = response.Data.Complemento,
                    Cep = response.Data.Cep,
                    ClienteId = response.Data.ClienteId
                };

        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }
    #endregion
    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.UpdateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Endereço atualizado", Severity.Success);
                NavigationManager.NavigateTo("/enderecos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
        
    }
    #endregion

    #region Private Methods

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
                InputModel.ClienteId = Clientes.FirstOrDefault()?.Id ?? 0;
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    #endregion
}
