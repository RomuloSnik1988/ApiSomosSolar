using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;

namespace SomosSolar.WebApp.Components.Reports
{
    public class TotalInstalacoesComponent : ComponentBase
    {
        #region Properties
        public int TInstalacoes { get; set; }
        #endregion
        #region Services
        [Inject]
        public IReportHandler Handler { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion
        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            await GetTotalInstalacoesAsync();
        }
        #endregion
        #region Methods
        public async Task GetTotalInstalacoesAsync()
        {
            try
            {
                var request = new GetTotalInstalacoesRequest();
                var result = await Handler.GetTotalInstalacaoAsync(request);
                if(!result.IsSuccess && result.Data is null)
                {
                    Snackbar.Add("Falha ao obter o total de instalações", Severity.Error);
                    return;
                }
                TInstalacoes = result.Data.TotalDeInstalacoes;
            }
            catch (HttpRequestException ex)
            {
                Snackbar.Add($"Erro na requisição Total Clientes: {ex.Message}", Severity.Error);
            }
        }
        #endregion
    }
}
