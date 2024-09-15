using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.User;

namespace MillionRealStateCompany.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserRequest userRequest)
        {
            return Ok(userService.Login(userRequest));
        }
    }
}
