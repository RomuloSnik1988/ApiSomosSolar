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
    public class EditEquipamentosModalPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public UpdateVendaRequest InputModel { get; set; } = new();
        public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
        public List<Equipamento> EquipamentosFiltrados { get; set; } = new List<Equipamento>();
        public ETipoEquipamento TipoEquipamentoSelecionado { get; set; }

        #endregion
        #region Parameters
        [Parameter]
        public int VendaId { get; set; }
        [CascadingParameter]
        public MudDialogInstance? ModalInstace { get; set; }
        #endregion
        #region Services
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]
        public IVendasHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            GetVendaByIdRequest? request = null;
            try
            {
                request = new GetVendaByIdRequest { Id = VendaId };
            }
            catch 
            {
                Snackbar.Add("Parametro Inválido", Severity.Error);
            }
            if (request is null)
                return;

            IsBusy = true;
            try
            {
                var response = await Handler.GetByIdAsync(request);
                if (response.IsSuccess && response.Data is not not null)
                    Snackbar.Add("Response Sucesso");
                    InputModel = new UpdateVendaRequest
                    {
                        Id = response.Data.Id,
                        EquipamentoId = response.Data.EquipamentoId,
                        Quantidade = response.Data.Quantidade,
                        InstalacaoId = response.Data.InstalacaoId
                    };
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }IsBusy = false;
        }
        #endregion
        #region Methods
        public void FiltrarEquipamentos()
        {
            EquipamentosFiltrados = Equipamentos
                .Where(e => e.Tipo == TipoEquipamentoSelecionado)
                .ToList();
        }
        public async Task UpdateAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    ModalInstace.Close(DialogResult.Ok(true));
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }finally { IsBusy = false; }
        }
       
        #endregion
    }
}
