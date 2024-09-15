using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Domain.Entities
{
    public class PropertyImage : BaseEntity
    {
        public string File { get; set; }

        public bool Enable { get; set; }

        public Guid PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
