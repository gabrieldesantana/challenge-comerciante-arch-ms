using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Enums;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAccountingEntryById
{
    public class SelectAccountingEntryByIdResponse
    {
        public SelectAccountingEntryByIdResponse(Guid id, string? description, decimal monetaryValue, EEntryType? entryType, DateTime date, DateTime createdAt)
        {
            Id = id;
            Description = description;
            MonetaryValue = monetaryValue;
            EntryType = entryType;
            Date = date;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string? Description { get; private set; }
        public decimal MonetaryValue { get; private set; }
        public EEntryType? EntryType { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static implicit operator SelectAccountingEntryByIdResponse(AccountingEntry accountingEntry)
            => new
            (
                accountingEntry.Id,
                accountingEntry.Description,
                accountingEntry.MonetaryValue,
                accountingEntry.Type,
                accountingEntry.Date,
                accountingEntry.CreatedAt
                );
    }
}
