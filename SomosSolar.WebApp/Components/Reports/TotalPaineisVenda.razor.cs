using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;

namespace SomosSolar.WebApp.Components.Reports;

public class TotalPaineisVendaComponent : ComponentBase
{
    #region Properties
    public int TPaineis { get; set; }
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
            await GetTotalPaineisVenda();
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro inesperado: {ex.Message}", Severity.Error);
        }
    }
    #endregion

    #region Methods
    private async Task GetTotalPaineisVenda()
    {
        try
        {
            var request = new GetTotalPaineisVendasRequest();
            var result = await Handler.GetTotalPaineisVendaAsync(request);
            if (!result.IsSuccess || result.Data is null)
            {
                Snackbar.Add("Falha ao obter total de Paineis", Severity.Error);
                return;
            }
            TPaineis = result.Data.TotalDePaineis;

            // Console.WriteLine("Total Paineis" + " " + TPaineis);
        }
        catch (HttpRequestException ex)
        {
            Snackbar.Add($"Erro na requisição Total Paineis: {ex.Message}", Severity.Error);
        }

    }

    #endregion

}
