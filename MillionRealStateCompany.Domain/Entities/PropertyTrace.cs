using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Domain.Entities
{
    public class PropertyTrace : BaseEntity
    {
        public DateTime? DateSale { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal Tax { get; set; }

        public Guid PropertyId { get; set; }

        public virtual Property Property { get; set; }

    }
}
