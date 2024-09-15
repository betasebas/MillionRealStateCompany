using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class PropertyTraceRepository(MillionRealStateCompanyContext context) : Repository<PropertyTrace>(context), IPropertyTraceRepository
    {
    }
}
