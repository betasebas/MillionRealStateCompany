using System.ComponentModel.DataAnnotations;

namespace MillionRealStateCompany.Application.Requests.User
{
    public class UserRequest
    {
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, ErrorMessage = "Maximum {2} characters exceeded")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(30, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Password { get; set; }
    }
}
