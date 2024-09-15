using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Shared.Filters;

namespace MillionRealStateCompany.Infrastructure.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        IOrderedEnumerable<Property> GetAllFilter(FilterProperty filterProperty);
    }
}
