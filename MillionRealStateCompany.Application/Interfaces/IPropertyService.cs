using MillionRealStateCompany.Application.Requests.Property;
using MillionRealStateCompany.Application.Responses;

namespace MillionRealStateCompany.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<Response> AddPropertyAsync(PropertyRequest propertyRequest);
        Task<Response> UpdatePropertyAsync(PropertyUpdateRequest propertyUpdateRequest);
        Task<Response> UpdatePriceProperty(PropertyPriceRequest propertyPriceRequest);
        PropertyListResponse GetAllByFilterAsync(FilterPropertyRequest filterPropertyRequest);
    }
}
