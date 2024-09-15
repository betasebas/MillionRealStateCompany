using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.CreatePropertyImage;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Abstrations;
using MillionRealStateCompany.Shared.Enums;

namespace MillionRealStateCompany.Application.Service
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PropertyImageService> _logger;

        public PropertyImageService(IPropertyImageRepository propertyImageRepository, IUnitOfWork unitOfWork, ILogger<PropertyImageService> logger, IFileService fileService)
        {
            _propertyImageRepository = propertyImageRepository;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response> AddImagenToProperty(PropertyImagenRequest propertyImagenRequest)
        {
            PropertyImage propertyImage = new PropertyImage
            {
                Enable = true,
                PropertyId = propertyImagenRequest.PropertyId,
                File = await _fileService.AddImageFolderDefault(propertyImagenRequest.File, Guid.NewGuid().ToString()),
            };

            _ = _propertyImageRepository.Create(propertyImage);
            int response = await _unitOfWork.CommitAsync();
            if(response < 1) 
            {
                _logger.LogInformation("An error occurred while saving the image");
                throw new ArgumentException("An error occurred while saving the image");
            }

            return new Response { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully" };
        }
    }
}
