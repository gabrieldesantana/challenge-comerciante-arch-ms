using Seller.JournalEntries.Domain.Entities;

namespace Seller.JournalEntries.Domain.Interfaces.Repository
{
    public interface IAccountingEntryRepository
    {
        Task<List<AccountingEntry>> GetAllAsync();
        Task<AccountingEntry> GetByIdAsync(Guid id);
        Task<AccountingEntry> CreateAsync(AccountingEntry accountingEntry);
    }
}
