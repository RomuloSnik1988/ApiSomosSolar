using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MudBlazor;
using SomoSSolar.Core.Handlers.Equipamentos;
using SomoSSolar.Core.Requests.Equipamentos;
using Tewr.Blazor.FileReader;

namespace SomosSolar.WebApp.Pages.Equipamentos;

public partial class CreateEquipamentoPage : ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateEquipamentosRequest InputModel { get; set; } = new();
    public IFormFile ImageFile { get; set; }
    public ElementReference inputReference { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public Stream fileStream { get; set; } = null!;

    string message = string.Empty;
    string imagePath = null;
    #endregion

    #region Services
    [Inject]
    public IEquipamentoHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    [Inject]
    public IFileReaderService fileReader { get; set; } = null!;

    #endregion

    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(ImageFile, InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/equipamentos");
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

    public async Task OpenFileAsync()
    {
        if (fileReader == null)
        {
            throw new NullReferenceException("O serviço fileReader não foi injetado corretamente.");
        }

        var file = (await fileReader.CreateReference(inputReference).EnumerateFilesAsync()).FirstOrDefault();

        if(file == null)
        {
            return;
        }

        var fileinfo = await file.ReadFileInfoAsync();
        FileName = fileinfo.Name;
        Size = $"{fileinfo.Size}b";
        Type = fileinfo.Type;

        //using (var ms = await file.CreateMemoryStreamAsync((int)fileinfo.Size))
        //{
        //    fileStream = new MemoryStream(ms.ToArray());
        //}

        using (var ms = await file.CreateMemoryStreamAsync((int)fileinfo.Size))
        {
            fileStream = new MemoryStream(ms.ToArray());
            ImageFile = new FormFile(fileStream, 0, fileStream.Length, FileName, FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = fileinfo.Type
            };
        }

    }

    #endregion

}
