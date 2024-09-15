using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.Property
{
    public class PropertyUpdateRequest
    {
        [Required(ErrorMessage = "This field is required.")]
        public Guid Id { get; set; }

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

        [Required(ErrorMessage = "This field is required.")]
        public bool Enable { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Guid OwnerId { get; set; }
    }
}
