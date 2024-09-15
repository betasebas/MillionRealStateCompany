using MillionRealStateCompany.Domain.Entities;

namespace MillionRealStateCompany.Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
