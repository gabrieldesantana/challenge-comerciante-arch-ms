using Seller.JournalEntries.Domain.Enums;

namespace Seller.JournalEntries.Domain.Entities
{
    public class AccountingEntry : BaseEntity
    {
        public AccountingEntry(Guid id, string? description, decimal monetaryValue, EEntryType? type, DateTime date)
        {
            Id = id;
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
