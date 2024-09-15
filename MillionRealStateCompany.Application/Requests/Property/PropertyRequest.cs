using Microsoft.AspNetCore.Http;
using MillionRealStateCompany.Shared.Validations;
using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.Property
{
    public class PropertyRequest
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, ErrorMessage = "Maximum {2} characters exceeded")]
        public string CodeInternal { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int Year { get; set; }

        //[Required(ErrorMessage = "This field is required.")]
        //[AllowedExtensionsAttributee]
        //public List<IFormFile> Files { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public OwnerRequest Owner { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public PropertyTraceRequest PropertyTrace { get; set; }
    }
}
