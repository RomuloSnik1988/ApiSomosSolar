using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Requests.Clientes;

namespace SomosSolar.WebApp.Pages.Clientes;

public class EditClientePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public UpdateClienteRequest InputModel { get; set; } = new();
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
    public IClienteHandler Handler { get; set; } = null!;
    
    #endregion

    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        GetClienteByIdRequest? request = null;
        try
        {
            request = new GetClienteByIdRequest
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
            var response = await Handler.GetByIdAsync(request);
            if (response.IsSuccess && response.Data is not null)
                InputModel = new UpdateClienteRequest
                {
                    Id = response.Data.Id,
                    Nome = response.Data.Nome,
                    Documento = response.Data.Documento,
                    Celular = response.Data.Celular,
                    Email = response.Data.Email,
                    DataCadastro = response.Data.DataCadastro
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
                Snackbar.Add("Dados do cliente atualizado com sucesso", Severity.Success);
                NavigationManager.NavigateTo("/clientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Success);
        }
        finally { IsBusy = false; }
    }
    #endregion
}
