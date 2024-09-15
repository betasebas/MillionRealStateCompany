using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.CreatePropertyImage;

namespace MillionRealStateCompany.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PropertyImageController(IPropertyImageService propertyImageService) : ControllerBase
    {
        [HttpPost("CreateImageProperty")]
        public async Task<IActionResult> CreateImagePropertyAsync([FromForm] PropertyImagenRequest propertyImagenRequest)
        {
            return Ok(await propertyImageService.AddImagenToProperty(propertyImagenRequest));
        }
    }
}
