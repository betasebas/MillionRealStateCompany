using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MillionRealStateCompany.Application.Interfaces;

namespace MillionRealStateCompany.Application.Service
{
    public class FileService(IHostEnvironment environment) : IFileService
    {
        public async Task<string> AddImageFolderDefault(IFormFile formFile, string fileName)
        {
            string contentPath = environment.ContentRootPath;
            string path = Path.Combine(contentPath, "fileProperties");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ext = Path.GetExtension(formFile.FileName);
            var fileNameWithPath = Path.Combine(path, $"{fileName}.{ext}");
            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return fileNameWithPath;
        }

        public void DeleteImageFolder(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Invalid file path");
            }

            File.Delete(fullPath);
        }
    }
}
