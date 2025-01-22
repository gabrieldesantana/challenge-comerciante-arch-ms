using Seller.JournalEntries.Domain.Entities;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries
{
    public class SelectAllAccountingEntriesResponse
    {
        public SelectAllAccountingEntriesResponse(List<AccountingEntry> accountingEntries)
        {
            AccountingEntries = accountingEntries;
        }

        public List<AccountingEntry> AccountingEntries { get; private set; }

        public static implicit operator SelectAllAccountingEntriesResponse(List<AccountingEntry> accountingEntries)
            => new (accountingEntries);
    }
}
