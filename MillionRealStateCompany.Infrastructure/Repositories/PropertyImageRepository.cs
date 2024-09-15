using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class PropertyImageRepository(MillionRealStateCompanyContext context) : Repository<PropertyImage>(context), IPropertyImageRepository
    {
    }
}
