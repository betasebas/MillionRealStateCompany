using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Domain.Entities
{
    public class Property : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public string CodeInternal { get; set; }

        public int Year { get; set; }

        public bool Enable { get; set; } = true;

        public Guid OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual PropertyTrace PropertyTrace { get; set; }

        public virtual IEnumerable<PropertyImage> PropertyImages { get; set; }
    }
}
