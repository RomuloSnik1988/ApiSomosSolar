using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Enderecos;
using SomoSSolar.Core.Handlers.Instalacoes;
using SomoSSolar.Core.Models;
using SomoSSolar.Core.Requests.Enderecos;
using SomoSSolar.Core.Requests.Instalacoes;

namespace SomosSolar.WebApp.Pages.Instalacoes;

public partial class CreateFormInstacalaoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateInstalacaoRequest InputModel { get; set; } = new();
    public GetEnderecoByIdRequest? EnderecoInputModel { get; set; }
    public Endereco? Enderecos { get; set; } 
    #endregion
    #region Parameters
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public IInstacacaoHandler Handler { get; set; } = null!;
    //[Inject]
    //public IClienteHandler ClienteHandler { get; set; } = null!;
    [Inject]
    public IEnderecoHandler EnderecoHandler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion
    #region Override
    protected override async Task OnInitializedAsync()
    {
        if(!int.TryParse(Id, out var enderecoId))
        {
            Snackbar.Add("Parêmetro inválido", Severity.Error);
            return;
        }
        IsBusy = true;
        try
        {
            var request = new GetEnderecoByIdRequest { Id = enderecoId };
            var response = await EnderecoHandler.GetByIdAsync(request);

            if(response.IsSuccess && response.Data is not null)
            {
                EnderecoInputModel = new GetEnderecoByIdRequest
                {
                    Id = enderecoId,
                };
                Enderecos = response.Data;
                // Preencher automaticamente o EnderecoId no InputModel
                InputModel.EnderecoId = response.Data.Id;
                InputModel.ClienteId = response.Data.ClienteId;
                Console.WriteLine("ClienteID", InputModel.EnderecoId);
            }
            else
            {
                Snackbar.Add("Endereço não encontrado", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally { IsBusy = false; }
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
                NavigationManager.NavigateTo($"/addEquipamentos/{requestId}");

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
        finally
        {
            IsBusy = false;
        }
    }
   
    #endregion
}
