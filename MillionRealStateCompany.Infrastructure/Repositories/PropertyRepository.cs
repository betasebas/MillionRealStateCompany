
using Abp.Collections.Extensions;
using Microsoft.EntityFrameworkCore;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Filters;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class PropertyRepository(MillionRealStateCompanyContext context) : Repository<Property>(context), IPropertyRepository
    {
        public IOrderedEnumerable<Property> GetAllFilter(FilterProperty filterProperty) =>
        
            DbSet
            .Include(x => x.Owner)
            .WhereIf(!string.IsNullOrEmpty(filterProperty.NameFilter), x => x.Name.Contains(filterProperty.NameFilter))
            .WhereIf(filterProperty.MaxYearFilter != null, x => x.Year <= filterProperty.MaxYearFilter)
            .WhereIf(filterProperty.MinYearFilter != null, x => x.Year >= filterProperty.MinYearFilter)
            .WhereIf(filterProperty.MaxPriceFilter != null, x => x.Price <= filterProperty.MaxPriceFilter)
            .WhereIf(filterProperty.MinPriceFilter != null, x => x.Price >= filterProperty.MinPriceFilter)
            .WhereIf(filterProperty.EnableFilter != null, x => x.Enable == filterProperty.EnableFilter)
            .WhereIf(!string.IsNullOrEmpty(filterProperty.NameOwnerFilter), x => x.Owner.Name.Contains(filterProperty.NameOwnerFilter))
            .OrderBy(x => x.Name);
        
    }
}
