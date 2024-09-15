namespace MillionRealStateCompany.Application.Requests.Property
{
    public class PropertyPriceRequest
    {
        public Guid PropertyId { get; set; }

        public decimal Value { get; set; }
    }
}
