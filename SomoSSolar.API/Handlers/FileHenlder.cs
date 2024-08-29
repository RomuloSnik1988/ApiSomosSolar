using SomoSSolar.Core.Handlers.FileService;

namespace SomoSSolar.API.Handlers
{
    public class FileHenlder(IWebHostEnvironment environment) : IFileHendler
    {
        public async Task<string> SaveFileAsync(IFormFile imageFile, string[] allowedFileExtensions)
        {
            if(imageFile == null)
            {
                throw new ArgumentNullException(nameof(imageFile));
            }

            var contentPath = environment.ContentRootPath;
            var path = Path.Combine(contentPath, "img", "equipamentos");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ext = Path.GetExtension(imageFile.FileName);
            if(!allowedFileExtensions.Contains(ext))
            {
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");
            }

            var fileName = $"{Guid.NewGuid().ToString()}{ext}";
            var fileNameWithPath = Path.Combine(path, fileName);
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await imageFile.CopyToAsync(stream);
            return fileName;
        }
        public void DeleteFile(string fileNameWithExtension)
        {
            throw new NotImplementedException();
        }

       
    }
}
