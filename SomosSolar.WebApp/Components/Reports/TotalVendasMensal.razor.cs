using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Reports;
using SomoSSolar.Core.Requests.Reports;

namespace SomosSolar.WebApp.Components.Reports
{
    public class TotalVendasMensalComponent : ComponentBase
    {
        #region Properties
        public ChartOptions Options { get; set; } = new();
        public List<ChartSeries> Series { get; set; } = null!;
        public List<string> Labels { get; set; } = [];
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
            var request = new GetTotalVendaMensalRequest();
            var result = await Handler.GetTotalVendasMensalAsync(request);
            if(!result.IsSuccess || result.Data is null)
            {
                Snackbar.Add("Não foi possível obter os dados do relatório de vendas anual", Severity.Error);
                return;
            }
            var vendaanual = new List<int>();

            foreach (var item in result.Data)
            {
                vendaanual.Add(item.TotalDeVendasMensal);
                Labels.Add(GetMonthName(item.Month));
            }
            Options.YAxisTicks = 4;
            Options.LineStrokeWidth = 3;
            Options.ChartPalette = [Colors.Green.Default];
            Series = 
                [
                new ChartSeries{Data = vendaanual.Select(x => (double)x).ToArray()},
                ];

            StateHasChanged();
        }
        #endregion
        private static string GetMonthName(int month) => new DateTime(DateTime.Now.Year, month, 1).ToString("MMMM");
    }
}
