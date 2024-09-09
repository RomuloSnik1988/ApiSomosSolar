using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Equipamentos;

namespace SomosSolar.WebApp.Pages.Equipamentos;

public partial class ListEquipamentosPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public List<Equipamento?> Equipamentos { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;

    public string ApiBaseUrl = Configuration.BackendUrl + ("/"); // URL base da API para imagens
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public IEquipamentoHandler Handler { get; set; } = null!;
    #endregion
    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllEquipamentosRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Equipamentos = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
    }
    #endregion
    #region Methods
    public async Task OnDeleteButtonClickedAsync(int id, string modelo)
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", $"Ao prosseguir o equipamento " +
            $"{modelo}, será exluído. Essa é uma ação irreversível! Deseja continuar?",
            yesText: "EXCLUIR",
            cancelText: "CANCELAR");

        if (result is true)
            await OnDeleteAsync(id, modelo);

        StateHasChanged();
    }
    public async Task OnDeleteAsync(int id, string modelo)
    {
        try
        {
            await Handler.DeleteAsync(new DeleteEquipamentoRequest { Id = id });
            Equipamentos.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Equipamento {modelo}, excluído", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    //Consulta
    public Func<Equipamento, bool> Filter => equipamento =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (equipamento.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (equipamento.Modelo.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (equipamento.Marca.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (equipamento.Fornecedor.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };
    #endregion
}
