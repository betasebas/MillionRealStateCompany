using Microsoft.Extensions.Logging;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.User;
using MillionRealStateCompany.Application.Service;
using MillionRealStateCompany.Domain.Entities;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Shared.Enums;
using Moq;
using System.Linq.Expressions;

namespace MillionRealStateCompany.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<ITokenService> _tokenService;
        private Mock<ILogger<UserService>> _logger;

        private IHashPasswordService _hashPasswordService;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _tokenService = new Mock<ITokenService>();
            _logger = new Mock<ILogger<UserService>>();
            _hashPasswordService = new HashPasswordService();

      
            _tokenService.Setup(x => x.GetToken(It.IsAny<User>())).Returns("diuhgiudsjger5rt4jr6tj746e4gf6w4gvwe54g6");

            _userService = new UserService(_userRepository.Object, _hashPasswordService, _tokenService.Object, _logger.Object);
        }


        [Test]
        public async Task CreateNewPropertyOk()
        {
            User user = new User { Password = "858585", UserName = "admin", Rol = "admin" };
            _userRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
            UserRequest userRequest = new UserRequest { Password = "858585", UserName = "admin" };
            var response = _userService.Login(userRequest);

            Assert.IsTrue((int)CodesResponse.Ok == response.Code);
        }


        [Test]
        public async Task CreateNewPropertyError()
        {
            User user = null;
            _userRepository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
            UserRequest userRequest = new UserRequest { Password = "858585", UserName = "admin" };
            Assert.Throws<ArgumentException>(() => _userService.Login(userRequest));
        }
    }
}
