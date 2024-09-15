using MillionRealStateCompany.Application.Requests.CreatePropertyImage;
using MillionRealStateCompany.Application.Responses;

namespace MillionRealStateCompany.Application.Interfaces
{
    public interface IPropertyImageService
    {
        Task<Response> AddImagenToProperty(PropertyImagenRequest propertyImagenRequest);
    }
}
