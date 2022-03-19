namespace EzPay.ServiceProvider.Domain
{
    public class ServiceProviderProfile : EntityBase
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string BRN { get; set; }
    }
}