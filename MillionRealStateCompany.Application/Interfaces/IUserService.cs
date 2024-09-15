using MillionRealStateCompany.Application.Requests.User;
using MillionRealStateCompany.Application.Responses;

namespace MillionRealStateCompany.Application.Interfaces
{
    public interface IUserService
    {
        UserResponse Login(UserRequest userRequest);
    }
}
