namespace Seller.DailyReport.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
