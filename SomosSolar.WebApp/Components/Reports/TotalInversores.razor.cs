using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;

namespace SomosSolar.WebApp.Components.Reports
{
    public class TotalInversoresComponent : ComponentBase
    {
        #region Properties
        public int TInversores { get; set; }
        #endregion
        #region Services
        [Inject]
        public IReportHandler Handler { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; }
        #endregion
        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            await GetTotalInversoresVenda();  
        }
        #endregion
        #region Methods
        private async Task GetTotalInversoresVenda()
        {
            try
            {
                var request = new GetTotalInvesoresRequest();
                var result = await Handler.GetTotalInversoresAsync(request);
                if (!result.IsSuccess && result.Data is null)
                {
                    Snackbar.Add("Falha ao obter total de inversores", Severity.Error);
                    return;
                }
                TInversores = result.Data.TotalDeInversores;
            }
            catch (HttpRequestException ex)
            {
                Snackbar.Add($"Erro na requisição total de inversores: {ex.Message}", Severity.Error);
            }
        }
        #endregion
    }
}
