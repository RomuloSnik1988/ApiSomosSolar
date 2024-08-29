using Microsoft.AspNetCore.Http;

namespace SomoSSolar.Core.Handlers.FileService
{
    public interface IFileHendler
    {
        Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions);
        void DeleteFile(string fileNameWithExtension);
    }
       
}
