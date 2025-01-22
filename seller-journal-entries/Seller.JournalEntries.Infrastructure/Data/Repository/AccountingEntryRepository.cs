using Microsoft.EntityFrameworkCore;
using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Interfaces.Repository;
using Seller.JournalEntries.Infrastructure.Data.Context;

namespace Seller.JournalEntries.Infrastructure.Data.Repository
{
    public class AccountingEntryRepository : IAccountingEntryRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<AccountingEntry> _dbSet;

        public AccountingEntryRepository(AppDbContext context)
            => (_context, _dbSet) = (context, context.Set<AccountingEntry>());


        public async Task<AccountingEntry> CreateAsync(AccountingEntry accountingEntry)
        {
            await _dbSet.AddAsync(accountingEntry);
            _context.SaveChanges();
            return accountingEntry;
        }

        public async Task<List<AccountingEntry>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<AccountingEntry> GetByIdAsync(Guid id)
        {
            return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
