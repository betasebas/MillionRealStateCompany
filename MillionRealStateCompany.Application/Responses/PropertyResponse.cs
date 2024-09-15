using MillionRealStateCompany.Domain.Entities;

namespace MillionRealStateCompany.Application.Responses
{
    public class PropertyListResponse : Response
    {
        public List<PropertyResponse> Data { get; set; }
    }

    public class PropertyResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public string CodeInternal { get; set; }

        public int Year { get; set; }

        public bool Enable { get; set; }

        public Guid OwnerId { get; set; }

        public OwnerResponse Owner { get; set; }

    }

    public class OwnerResponse 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }
    }
}
