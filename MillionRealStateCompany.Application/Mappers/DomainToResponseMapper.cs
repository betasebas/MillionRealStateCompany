using AutoMapper;
using MillionRealStateCompany.Application.Requests.Property;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Shared.Filters;

namespace MillionRealStateCompany.Application.Mappers
{
    public class DomainToResponseMapper : Profile
    {
        public DomainToResponseMapper()
        {
            CreateMap<PropertyRequest, Property>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CodeInternal, opt => opt.MapFrom(src => src.CodeInternal))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));
  
            CreateMap<OwnerRequest, Owner>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday));

            CreateMap<PropertyTraceRequest, PropertyTrace>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
               .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
               .ForMember(dest => dest.DateSale, opt => opt.MapFrom(src => src.DateSale));

            CreateMap<FilterPropertyRequest, FilterProperty>()
               .ForMember(dest => dest.EnableFilter, opt => opt.MapFrom(src => src.EnableFilter))
               .ForMember(dest => dest.NameFilter, opt => opt.MapFrom(src => src.NameFilter))
               .ForMember(dest => dest.MaxPriceFilter, opt => opt.MapFrom(src => src.MaxPriceFilter))
               .ForMember(dest => dest.MinPriceFilter, opt => opt.MapFrom(src => src.MinPriceFilter))
               .ForMember(dest => dest.MaxYearFilter, opt => opt.MapFrom(src => src.MaxYearFilter))
               .ForMember(dest => dest.MinYearFilter, opt => opt.MapFrom(src => src.MinYearFilter))
               .ForMember(dest => dest.NameOwnerFilter, opt => opt.MapFrom(src => src.NameOwnerFilter));

            CreateMap<PropertyResponse, Property>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Enable, opt => opt.MapFrom(src => src.Enable))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CodeInternal, opt => opt.MapFrom(src => src.CodeInternal))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));
                //.ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));
        }
    }
}
