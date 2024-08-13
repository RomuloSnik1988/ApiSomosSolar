using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Vendas;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Requests.Vendas;

namespace SomosSolar.WebApp.Pages.Vendas;

public class CreateVendaPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateVendaRequest InputModel { get; set; } = new();
    public GetEnderecoByIdRequest? EnderecoInputModel { get; set; }
    public Endereco? Endereco { get; set; }
    #endregion

    #region Parameters
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion

    #region Services
    [Inject]
    public IVendasHandler Handler { get; set; } = null!;
    [Inject]
    public IEnderecoHandler EnderecoHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; }
    #endregion

    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion
}
