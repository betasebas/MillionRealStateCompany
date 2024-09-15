using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Context;
using MillionRealStateCompany.Infrastructure.Interfaces;

namespace MillionRealStateCompany.Infrastructure.Repositories
{
    public class UserRepository(MillionRealStateCompanyContext context) : Repository<User>(context), IUserRepository
    {
      
    }
}
