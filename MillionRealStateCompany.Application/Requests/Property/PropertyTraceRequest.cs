using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.Property
{
    public class PropertyTraceRequest
    {
        public DateTime? DateSale { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Tax { get; set; }
    }
}
