using Microsoft.AspNetCore.Http;

namespace MillionRealStateCompany.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> AddImageFolderDefault(IFormFile formFile, string fileName);

        void DeleteImageFolder(string fullPath);
    }
}
