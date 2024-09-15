using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.Property;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Infrastructure.Repositories;
using MillionRealStateCompany.Shared.Abstrations;
using MillionRealStateCompany.Shared.Enums;
using MillionRealStateCompany.Shared.Filters;
using System.Linq.Dynamic.Core;

namespace MillionRealStateCompany.Application.Service
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PropertyService> _logger;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository propertyRepository, IPropertyTraceRepository propertyTraceRepository,
              IUnitOfWork unitOfWork, ILogger<PropertyService> logger, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _propertyTraceRepository = propertyTraceRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Response> AddPropertyAsync(PropertyRequest propertyRequest)
        {
            try
            {
                _logger.LogInformation("Starts the operation of saving a property");
                _logger.LogInformation("Property creation with Owner");
                Property property = _mapper.Map<Property>(propertyRequest);
                Property PropertyCreated = _propertyRepository.Create(property);
                _logger.LogInformation("PropertyTrace creation");
                PropertyTrace propertyTrace = _mapper.Map<PropertyTrace>(propertyRequest.PropertyTrace);
                propertyTrace.PropertyId = PropertyCreated.Id;
                _ = _propertyTraceRepository.Create(propertyTrace);
                await _unitOfWork.CommitAsync();
                _logger.LogInformation("The operation was completed successfully");
                return new Response { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in transaction");
                throw;
            }      
        }

        public PropertyListResponse GetAllByFilterAsync(FilterPropertyRequest filterPropertyRequest)
        {
            FilterProperty filterProperty = _mapper.Map<FilterProperty>(filterPropertyRequest);
            var propertiesQuery = _propertyRepository.GetAllFilter(filterProperty);
            if(propertiesQuery == null) 
            {
                _logger.LogInformation("An error has occurred in the process");
                throw new ArgumentException("An error has occurred in the process");
            }

            List<Property> properties = propertiesQuery.ToList();
            List<PropertyResponse> propertyResponses = new List<PropertyResponse>();
            foreach (var property in properties)
            {
                propertyResponses.Add(new PropertyResponse 
                {
                    Id = property.Id,
                    Enable = property.Enable,
                    Address = property.Address,
                    CodeInternal = property.CodeInternal,
                    Name = property.Name,
                    OwnerId = property.OwnerId,
                    Price = property.Price,
                    Year = property.Year,
                    Owner = new OwnerResponse { Name = property.Owner.Name, Address = property.Owner.Address, Birthday = property.Owner.Birthday, Id = property.Owner.Id, Phone = property.Owner.Phone },
                });
            }

            return new PropertyListResponse { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully", Data = propertyResponses };

        }

        public async Task<Response> UpdatePriceProperty(PropertyPriceRequest propertyPriceRequest)
        {
            Property propertyOld = _propertyRepository.GetByCondition(x => x.Id == propertyPriceRequest.PropertyId);
            if (propertyOld == null)
            {
                _logger.LogInformation("An error has occurred in the process");
                throw new ArgumentException("An error has occurred in the process");
            }

            propertyOld.Price = propertyPriceRequest.Value;
            _propertyRepository.Update(propertyOld);
            await _unitOfWork.CommitAsync();
            return new Response { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully" };
        }

        public async Task<Response> UpdatePropertyAsync(PropertyUpdateRequest propertyUpdateRequest)
        {
            Property propertyOld = _propertyRepository.GetByCondition(x => x.Id == propertyUpdateRequest.Id);
            if(propertyOld == null) 
            {
                _logger.LogInformation("An error has occurred in the process");
                throw new ArgumentException("An error has occurred in the process");
            }

            propertyOld.Address = propertyUpdateRequest.Address;
            propertyOld.Name = propertyUpdateRequest.Name;
            propertyOld.CodeInternal = propertyUpdateRequest.CodeInternal;
            propertyOld.Enable = propertyOld.Enable;
            propertyOld.OwnerId = propertyUpdateRequest.OwnerId;
            propertyOld.Year = propertyUpdateRequest.Year;
            propertyOld.Price = propertyUpdateRequest.Price;

            _propertyRepository.Update(propertyOld);
            await _unitOfWork.CommitAsync();
            return new Response { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully" };
        }
    }
}
