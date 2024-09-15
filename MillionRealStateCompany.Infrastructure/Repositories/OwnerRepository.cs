using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class OwnerRepository(MillionRealStateCompanyContext context) : Repository<Owner>(context), IOwnerRepository
    {

    }
}
