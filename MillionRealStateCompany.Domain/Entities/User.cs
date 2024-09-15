using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }
    }
}
