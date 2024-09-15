using AutoMapper;
using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Mappers;
using MillionRealStateCompany.Application.Requests.Property;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Application.Service;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Abstrations;
using MillionRealStateCompany.Shared.Enums;
using MillionRealStateCompany.Shared.Filters;
using Moq;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MillionRealStateCompany.Test
{
    [TestFixture]
    public class PropertyTest
    {
        private Mock<IPropertyRepository> _propertyRepository;
        private Mock<IPropertyTraceRepository> _propertyTraceRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<ILogger<PropertyService>> _logger;
        private IMapper _mapper;
        private PropertyService _propertyService;

        private Property property;
        private PropertyTrace propertTrace;
        private PropertyUpdateRequest propertyUpdateRequest;

        [SetUp]
        public void Setup()
        {
            _propertyRepository = new Mock<IPropertyRepository>();
            _propertyTraceRepository = new Mock<IPropertyTraceRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _logger = new Mock<ILogger<PropertyService>>();

            property = JsonConvert.DeserializeObject<Property>(File.ReadAllText("data/propertyMock.json"));
            propertTrace = JsonConvert.DeserializeObject<PropertyTrace>(File.ReadAllText("data/propertyTrace.json"));
            propertyUpdateRequest = JsonConvert.DeserializeObject<PropertyUpdateRequest>(File.ReadAllText("data/propertyUpdate.json"));

            _propertyRepository.Setup(x => x.Create(It.IsAny<Property>())).Returns(property);
            _propertyRepository.Setup(x => x.Update(It.IsAny<Property>()));

            _propertyTraceRepository.Setup(x => x.Create(It.IsAny<PropertyTrace>())).Returns(propertTrace);
            _unitOfWork.Setup(x => x.CommitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            MapperConfiguration mapperConfig = new MapperConfiguration(
             cfg =>
             {
                 cfg.AddProfile(new DomainToResponseMapper());
             });

            _mapper = new Mapper(mapperConfig);

            _propertyService = new PropertyService(_propertyRepository.Object, _propertyTraceRepository.Object, _unitOfWork.Object, _logger.Object, _mapper);
        }

        [Test]
        public async Task CreateNewPropertyOk()
        {

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText("data/propertyMockCreation.json"));
            Response response = await _propertyService.AddPropertyAsync(propertyRequest);

            // Assert
            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }


        [Test]
        public async Task CreateNewPropertyError()
        {

            PropertyRequest propertyRequest = JsonConvert.DeserializeObject<PropertyRequest>(File.ReadAllText("data/propertyMockCreation.json"));
            propertyRequest.PropertyTrace = null;
            Assert.ThrowsAsync<NullReferenceException>(async () => await _propertyService.AddPropertyAsync(propertyRequest));
        }

        [Test]
        public void GetAllByFilterOk()
        {
            List<Property> properties = JsonConvert.DeserializeObject<List<Property>>(File.ReadAllText("data/propertiesMock.json"));
            _propertyRepository.Setup(x => x.GetAllFilter(It.IsAny<FilterProperty>())).Returns(properties.OrderBy(x => x.Price));
            FilterPropertyRequest filterProperty = new FilterPropertyRequest { EnableFilter = true, NameFilter = "LoCastle" };
            Response response =  _propertyService.GetAllByFilterAsync(filterProperty);

            // Assert
            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }

        [Test]
        public void GetAllByFilterError()
        {
            IOrderedEnumerable<Property> properties = null;
            _propertyRepository.Setup(x => x.GetAllFilter(It.IsAny<FilterProperty>())).Returns(properties);
            FilterPropertyRequest filterProperty = new FilterPropertyRequest { EnableFilter = true, NameFilter = "LoCastle" };

            Assert.Throws<ArgumentException>(() => _propertyService.GetAllByFilterAsync(filterProperty));

        }

        [Test]
        public async Task  UpdatePriceOk()
        {
            _propertyRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<Property, bool>>>())).Returns(property);
            PropertyPriceRequest propertyPriceRequest = new PropertyPriceRequest { PropertyId = Guid.NewGuid(), Value = 256000000};
            Response response = await _propertyService.UpdatePriceProperty(propertyPriceRequest);

            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }

        [Test]
        public void UpdatePriceError()
        {
            Property property = null;
            _propertyRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<Property, bool>>>())).Returns(property);
            PropertyPriceRequest propertyPriceRequest = new PropertyPriceRequest { PropertyId = Guid.NewGuid(), Value = 256000000 };
            Assert.ThrowsAsync<ArgumentException>(async () => await _propertyService.UpdatePriceProperty(propertyPriceRequest));
        }

        [Test]
        public async Task UpdatePropertyOk()
        {
            _propertyRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<Property, bool>>>())).Returns(property);
            Response response = await _propertyService.UpdatePropertyAsync(propertyUpdateRequest);

            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }

        [Test]
        public void UpdatePropertyError()
        {
            Property property = null;
            _propertyRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<Property, bool>>>())).Returns(property);
            Assert.ThrowsAsync<ArgumentException>(async () => await _propertyService.UpdatePropertyAsync(propertyUpdateRequest));
        }
    }
}
