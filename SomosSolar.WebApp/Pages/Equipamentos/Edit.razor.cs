using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Requests.Equipamentos;

namespace SomosSolar.WebApp.Pages.Equipamentos;

public class EditEquipamentoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = true;
    public UpdateEquipamentoRequest InputModel { get; set; } = new();
    #endregion

    #region Parameters
    [Parameter]
    public string Id { get; set; } = string.Empty;
    #endregion
    #region Services
    [Inject]
    public IEquipamentoHandler Handler { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion
    #region Overrides
    protected override async Task OnInitializedAsync()
    {
        GetEquipamentoByIdRequest? request = null;
        try
        {
            request = new GetEquipamentoByIdRequest
            {
                Id = int.Parse(Id),
            };
        }
        catch
        {
            Snackbar.Add("Parametro inválido", Severity.Error);
        }
        if (request is null)
            return;

        IsBusy = true;
        try
        {
            var response = await Handler.GetByIdAsync(request);
            if (response.IsSuccess && response.Data is not null)
                InputModel = new UpdateEquipamentoRequest
                {
                    Id = response.Data.Id,
                    Tipo = response.Data.Tipo,
                    Fornecedor = response.Data.Fornecedor,
                    Marca = response.Data.Marca,
                    Modelo = response.Data.Modelo,
                    Potencia = response.Data.Potencia,
                    PotenciaMaxima = response.Data.PotenciaMaxima,
                    Peso = response.Data.Peso,
                    Tamanho = response.Data.Tamanho,
                    ImagemUrl = response.Data.ImagemUrl,
                    Ativo = response.Data.Ativo,
                };
        }
        catch (Exception ex)
        {
Snackbar.Add(ex.Message, Severity.Error);
        }finally { IsBusy = false; }

    }
    #endregion
    #region Private Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.UpdateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Equipamento atualizado", Severity.Success);
                NavigationManager.NavigateTo("/equipamentos");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    #endregion
}
