﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using SomoSSolar.Core.Handlers.Clientes;
using SomoSSolar.Core.Requests.Cliente;
using SomoSSolar.Core.Requests.Endereco;

namespace SomosSolar.WebApp.Pages.Clientes;

public partial class CreateClientePage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateClienteRequest InputModel { get; set; } = new();
    public CreateEnderecoRequest InputModelEndereco { get; set; } = new();
    #endregion

    #region Services
    [Inject]
    public IClienteHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion

    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess )
            {
                Snackbar.Add(result.Message, Severity.Success);
                var requestId = result.Data.Id;
                NavigationManager.NavigateTo($"/enderecos/adicionar/{requestId}");
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
    }
    #endregion
    
}
