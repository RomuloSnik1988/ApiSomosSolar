using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Instalacoes;

namespace SomosSolar.WebApp.Pages.Instalacoes;

public partial class ListInstalacoesPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public List<Instalacao> Instalacoes { get; set; } = new List<Instalacao>();
    public List<Cliente> Clientes { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public IInstacacaoHandler Handler { get; set; } = null!;

    #endregion
    #region Override
    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllInstacoesRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Instalacoes = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {

            IsBusy = false;
        }

    }
    #endregion
    #region Methods

    public async Task OnDeleteButtonClickedAsync(int id)
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", $"Ao prosseguir a instalação"+
            $"{id}, será excluida. Essa é uma ação irreversível! Deseja continuar?",
            yesText: "EXCLUIR",
            cancelText: "CANCELAR");

        if(result is true) 
            await OnDeleteAsync(id);

        StateHasChanged();
    }
    public async Task OnDeleteAsync(int id)
    {
        try
        {
            await Handler.DeleteAsync(new DeleteInstalacaoRequest { Id = id });
            Instalacoes.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Instalaçõa{id}, excluida", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    //Consulta
    public Func<Instalacao, bool> Filter => instalacao =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (instalacao.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (instalacao.ClienteId.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (instalacao.DataInstalacao.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;

    };
    #endregion
}
