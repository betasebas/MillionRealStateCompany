using Microsoft.AspNetCore.Http;
using MillionRealStateCompany.Shared.Validations;
using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.CreatePropertyImage
{
    public class PropertyImagenRequest
    {
        [Required(ErrorMessage = "This field is required.")]
        public Guid PropertyId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [AllowedExtensionsAttributee]
        public IFormFile File { get; set; }
    }
}
