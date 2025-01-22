using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Enums;

namespace Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry
{
    public class InsertAccountingEntryResponse
    {
        public InsertAccountingEntryResponse(string? description, decimal monetaryValue, EEntryType? entryType, DateTime date)
        {
            Description = description;
            MonetaryValue = monetaryValue;
            EntryType = entryType;
            Date = date;
        }

        public string? Description { get; private set; }
        public decimal MonetaryValue { get; private set; }
        public EEntryType? EntryType { get; private set; }
        public DateTime Date { get; private set; }

        public static implicit operator InsertAccountingEntryResponse(AccountingEntry accountingEntry)
        => new(
        accountingEntry.Description,
        accountingEntry.MonetaryValue,
        accountingEntry.Type,
        accountingEntry.Date
        );
    }
}
