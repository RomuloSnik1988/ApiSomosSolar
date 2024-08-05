using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;

namespace SomosSolar.WebApp.Pages.Clientes;

public class ListClientePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public List<Cliente> Clientes { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public IClienteHandler Handler { get; set; } = null!;
    #endregion

    #region Override
    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;
        try
        {
            var request = new GetAllClientesRequest();
            var result = await Handler.GetAllAsync(request);
            if (result.IsSuccess)
                Clientes = result.Data ?? [];
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {

        IsBusy = false; }
    
    }
    #endregion
    #region Methods
    public async Task OnDeleteButtonClikedAsync(int id, string nome)
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", $"Ao Prosseguir o cliente" + 
            $"{nome} será excluido. Essa é uma ação irreversível! Deseja continuar?",
            yesText:"EXCLUIR",
            cancelText:"CANCELAR");

        if(result is true) 
            await OnDeleteAsync(id, nome);

        StateHasChanged();
    }

    public async Task OnDeleteAsync(int id, string nome)
    {
        try
        {
            await Handler.DeleteAsync(new DeleteClienteRequest { Id = id });
            Clientes.RemoveAll(x=> x.Id == id);
            Snackbar.Add($"Cliente {nome} exluído", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    //Consulta
    public Func<Cliente, bool> Filter => cliente =>
    {
        if (string.IsNullOrEmpty(SearchTerm))
            return true;

        if (cliente.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        if (cliente.Nome.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;

    };
    #endregion
}
