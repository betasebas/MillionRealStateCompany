using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Requests.Property;

namespace MillionRealStateCompany.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class PropertyController(IPropertyService propertyService) : ControllerBase
    {
        [HttpPost("CreateProperty")]
        public async Task<IActionResult> CreatePropertyAsync([FromBody] PropertyRequest propertyRequest) 
        {
            return Ok(await propertyService.AddPropertyAsync(propertyRequest));
        }

        [HttpPatch("UpdatePriceProperty")]
        public async Task<IActionResult> UpdatePricePropertyAsync([FromBody] PropertyPriceRequest propertyPriceRequest)
        {
            return Ok(await propertyService.UpdatePriceProperty(propertyPriceRequest));
        }
        
        [HttpPut("UpdateProperty")]
        public async Task<IActionResult> UpdatePropertyAsync([FromBody] PropertyUpdateRequest propertyUpdateRequest)
        {
            return Ok(await propertyService.UpdatePropertyAsync(propertyUpdateRequest));
        }

        [HttpGet("GetProperties")]
        public IActionResult GetProperty([FromQuery] FilterPropertyRequest filterPropertyRequest)
        {
            return Ok(propertyService.GetAllByFilterAsync(filterPropertyRequest));
        }

    }
}
