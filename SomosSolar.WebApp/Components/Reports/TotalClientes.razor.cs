using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;

namespace SomosSolar.WebApp.Components.Reports;

public class TotalClientesComponent : ComponentBase
{
    #region Properties
    public int TClientes { get; set; }
    #endregion
    #region Services
    [Inject]
    public IReportHandler Handler { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion
    #region Override
    protected override async Task OnInitializedAsync()
    {
        try
        {
            await GetTotalClientes();
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro inesperado: {ex.Message}", Severity.Error);
        }
    }
    #endregion
    #region Methods
    private async Task GetTotalClientes()
    {
        try
        {
            var request = new GetTotalClientesRequest();
            var result = await Handler.GetTotalClientesAsync(request);
            if(!result.IsSuccess && result.Data is null)
            {
                Snackbar.Add("Falha ao obter total de Clientes", Severity.Error);
                return;
            }
            TClientes = result.Data.TotalDeClientes; 

        }
        catch (HttpRequestException ex)
        {
            Snackbar.Add($"Erro na requisição Total Clientes: {ex.Message}", Severity.Error);

        }
    }
    #endregion
}
