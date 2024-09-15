using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.User;
using MillionRealStateCompany.Application.Responses;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Enums;

namespace MillionRealStateCompany.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IHashPasswordService hashPasswordService, ITokenService tokenService, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
            _tokenService = tokenService;
            _logger = logger;
        }

        public UserResponse Login(UserRequest userRequest)
        {
            string passwordHash = _hashPasswordService.GenerateHash(userRequest.Password);
            User user = _userRepository.GetByCondition(x => x.UserName.Equals(userRequest.UserName) && x.Password.Equals(passwordHash));
            if(user == null) 
            {
                _logger.LogInformation("An error has occurred in the process. Incorrect username or password");
                throw new ArgumentException("An error has occurred in the process. Incorrect username or password");
            }

            string token = _tokenService.GetToken(user);
            return new UserResponse { Code = (int)CodesResponse.Ok, Message = "The operation was completed successfully", UserName = user.UserName, Token = token };
        }
    }
}
