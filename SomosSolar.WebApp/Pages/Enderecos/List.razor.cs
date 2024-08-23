using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;

namespace SomosSolar.WebApp.Pages.Enderecos;

public partial class ListEnderecoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public List<Endereco?> Enderecos { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public IEnderecoHandler Handler { get; set; } = null!;
    #endregion
    #region Override
    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllEnderecosRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Enderecos = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }finally { IsBusy = false; }
    }
    #endregion
    #region Methods
    public async Task onDeldeteButtonClickedAsync(int id, string lagradouro)
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", $"Ao Prosseguir o Endereço da" +
            $"{lagradouro} será excluido. Essa é uma ação irreversível! Deseja continuar?",
            yesText: "EXCLUIR",
            cancelText: "CANCELAR");

        if (result is true)
            await OnDeleteAsync(id, lagradouro);

        StateHasChanged();
    }
    public async Task OnDeleteAsync(int id, string lagradouro)
    {
        try
        {
            await Handler.DeleteAsync(new DeleteEnderecoRequest { Id = id });
            Enderecos.RemoveAll(x => x.Id == id);
            Snackbar.Add($"Endereço{lagradouro} excluído", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    //Consulta
    public Func<Endereco, bool> Filter => endereco =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (endereco.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (endereco.Logradouro.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (endereco.Bairro.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };
    #endregion
}
