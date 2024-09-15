using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.Property
{
    public class OwnerRequest
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(150, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(15, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public DateTime Birthday { get; set; }
    }
}
