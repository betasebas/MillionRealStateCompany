using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public virtual IEnumerable<Property> Properties { get; set; }
    }
}
