using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionRealStateCompany.Shared.Abstrations
{
    public abstract class BaseEntity : IEntityKey<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private init; }
    }
}
