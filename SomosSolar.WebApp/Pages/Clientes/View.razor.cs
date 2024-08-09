using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;

namespace SomosSolar.WebApp.Pages.Clientes;

public class ViewClientePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public Cliente? Cliente { get; set; }
    public GetClienteByIdRequest? InputModel { get; set; }
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
            }
        }
        catch 
        {
            Snackbar.Add("Cliente não encontrado", Severity.Error);
        }finally { IsBusy = false; }
    }
       
    #endregion
   
}
