using Microsoft.EntityFrameworkCore;
using Seller.DailyReport.Domain.Entities;
using Seller.DailyReport.Domain.Interfaces.Repository;
using Seller.DailyReport.Infrastructure.Data.Context;

namespace Seller.DailyReport.Infrastructure.Data.Repository
{
    public class AccountingEntryRepository : IAccountingEntryRepository
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<AccountingEntry> _dbSet;

        public AccountingEntryRepository(AppDbContext context)
            => (_context, _dbSet) = (context, context.Set<AccountingEntry>());

        public async Task<List<AccountingEntry>> GetAllOfTodayAsync() => 
            await _dbSet
            .Where(a => DateTime.SpecifyKind(a.Date.Date,DateTimeKind.Unspecified ) == DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Unspecified))
            .ToListAsync();
    }
}
