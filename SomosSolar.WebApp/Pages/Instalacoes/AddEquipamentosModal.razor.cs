using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Enums;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;
using SomoSSolar.Core.Requests.Vendas;

namespace SomosSolar.WebApp.Pages.Instalacoes
{
    public class AddEquipamentosModalPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateVendaRequest InputModel { get; set; } = new();
        public UpdateEquipamentoRequest? EquipamentosInputModel { get; set; }
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
        public List<Equipamento> EquipamentosFiltrados { get; set; } = new List<Equipamento>();
        public ETipoEquipamento TipoEquipamentoSelecionado { get; set; }

        #endregion
        #region Parameters
        [Parameter]
        public int InstalacaoId { get; set; }
        [CascadingParameter]
        public MudDialogInstance ModalInstace { get; set; }
        #endregion
        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]
        public IEquipamentoHandler EquipamentoHandler { get; set; } = null!;
        [Inject]
        public IVendasHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                // Use o EnderecoId como necessário
                Console.WriteLine($"EnderecoId recebido: {InstalacaoId}");

                var request = new GetAllEquipamentosRequest();
                var result = await EquipamentoHandler.GetAllAsync(request);
                if (result.IsSuccess)
                    Equipamentos = result.Data ?? new List<Equipamento>();
                InputModel.InstalacaoId = InstalacaoId;
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }
        #endregion
        #region Methods
        public void FiltrarEquipamentos()
        {
            EquipamentosFiltrados = Equipamentos
                .Where(e => e.Tipo == TipoEquipamentoSelecionado)
                .ToList();
            //Console.WriteLine(TipoEquipamentoSelecionado);
        }
        public async Task SalvarAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    ModalInstace.Close();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        #endregion
    }
}
