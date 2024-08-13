using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Clientes;
using SomoSSolar.Core.Requests.Endereco;

namespace SomosSolar.WebApp.Pages.Enderecos;

public class CreateFormEnderecoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateEnderecoRequest InputModel { get; set; } = new();
    public GetClienteByIdRequest? ClienteInputModel { get; set; } 
    public Cliente? Clientes { get; set; }
    #endregion
    #region Parameters
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public IEnderecoHandler Handler { get; set; } = null!;
    [Inject]
    public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Override
    protected override async Task OnInitializedAsync()
    {
        if (!int.TryParse(Id, out var clienteId))
        {
            Snackbar.Add("Parâmetro inválido", Severity.Error);
            return;
        }

        IsBusy = true;
        try
        {
            var request = new GetClienteByIdRequest { Id = clienteId };
            var response = await ClienteHandler.GetByIdAsync(request);

            if (response.IsSuccess && response.Data is not null)
            {
                ClienteInputModel = new GetClienteByIdRequest
                {
                    Id = response.Data.Id,
                };
                Clientes = response.Data;
                // Preencher automaticamente o ClienteId no InputModel
                InputModel.ClienteId = response.Data.Id;
            }
            else
            {
                Snackbar.Add("Cliente não encontrado", Severity.Error);
            }
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
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                var requestId = result.Data.Id;
                NavigationManager.NavigateTo($"/instalacao/adicionarForm/{requestId}");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
        #endregion
    }
    //public async Task RetornarId()
    //{
    //    try
    //    {
    //        var request = int.Parse(Id);

    //    }
    //    catch
    //    {
    //        Snackbar.Add("Parametro Inválido");
    //    }
    //}

    //private async Task GetClientesAsync()
    //{
    //    IsBusy = true;
    //    try
    //    {
    //        var request = new GetAllClientesRequest();
    //        var result = await ClienteHandler.GetAllAsync(request);
    //        if (result.IsSuccess)
    //        {
    //            Cliente = result.Data ?? [];
    //            InputModel.ClienteId = Cliente.FirstOrDefault()?.Id ?? 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Snackbar.Add(ex.Message, Severity.Error);
    //    }
    //}
}