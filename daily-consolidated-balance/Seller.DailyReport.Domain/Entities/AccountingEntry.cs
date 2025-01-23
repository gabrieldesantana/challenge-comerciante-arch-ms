using Seller.DailyReport.Domain.Enums;

namespace Seller.DailyReport.Domain.Entities
{
    public class AccountingEntry : BaseEntity
    {
        public AccountingEntry(string? description, decimal monetaryValue, EEntryType? type, DateTime date)
        {
            Description = description;
            MonetaryValue = monetaryValue;
            Type = type;
            Date = date;
        }

        public string? Description { get; private set; }
        public decimal MonetaryValue { get; private set; }
        public EEntryType? Type { get; private set; }
        public DateTime Date { get; private set; }
    }
}
