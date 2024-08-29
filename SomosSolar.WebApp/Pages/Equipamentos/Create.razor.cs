using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Requests.Equipamentos;

namespace SomosSolar.WebApp.Pages.Equipamentos;

public partial class CreateEquipamentoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateEquipamentosRequest InputModel { get; set; } = new();

    public IFormFile MyProperty { get; set; }
    #endregion

    #region Services
    [Inject]
    public IEquipamentoHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
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
                NavigationManager.NavigateTo("/equipamentos");
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
    }
    #endregion

}
