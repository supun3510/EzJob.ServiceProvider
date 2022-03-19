namespace EzPay.ServiceProvider.Domain
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}