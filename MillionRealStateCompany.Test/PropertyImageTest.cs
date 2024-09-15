using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.CreatePropertyImage;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Application.Service;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Abstrations;
using MillionRealStateCompany.Shared.Enums;
using Moq;

namespace MillionRealStateCompany.Test
{
    [TestFixture]
    public class PropertyImageTest
    {
        private Mock<IPropertyImageRepository> _propertyImageRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<ILogger<PropertyImageService>> _logger;
        private Mock<IHostEnvironment> _environment;
        private IFileService _fileService;
        private Mock<IFormFile> _file;
        private PropertyImageService _propertyImageService;

        [SetUp]
        public void Setup()
        {
            _propertyImageRepository = new Mock<IPropertyImageRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<PropertyImageService>>();
            _environment = new Mock<IHostEnvironment>();

            _propertyImageRepository.Setup(x => x.Create(It.IsAny<PropertyImage>())).Returns(new PropertyImage());

            _environment.Setup(x => x.ContentRootPath).Returns("data");
            _fileService = new FileService(_environment.Object);

            byte[] bytes = File.ReadAllBytes("data/LothricCastle.jpg");
            var stream = new MemoryStream(bytes);

            _file = new Mock<IFormFile>();
            _file.Setup(f => f.FileName).Returns("LothricCastle");
            _file.Setup(f => f.Length).Returns(stream.Length);
            _file.Setup(f => f.OpenReadStream()).Returns(stream);
            _file.Setup(f => f.ContentType).Returns("image/*");

            _propertyImageService = new PropertyImageService(_propertyImageRepository.Object, _unitOfWork.Object, _logger.Object, _fileService);
        }


        [Test]
        public async Task CreatePropertyImageOk()
        {
            _unitOfWork.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            PropertyImagenRequest propertyImagenRequest = new PropertyImagenRequest 
            {
                PropertyId = Guid.NewGuid(),
                File = _file.Object
            };
            Response response = await _propertyImageService.AddImagenToProperty(propertyImagenRequest);

            // Assert
            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }

        [Test]
        public async Task CreatePropertyImageError()
        {
            _unitOfWork.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            PropertyImagenRequest propertyImagenRequest = new PropertyImagenRequest
            {
                PropertyId = Guid.NewGuid(),
                File = _file.Object
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await _propertyImageService.AddImagenToProperty(propertyImagenRequest));
        }
    }
}
