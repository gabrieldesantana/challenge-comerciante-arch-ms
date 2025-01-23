using Seller.DailyReport.Domain.Entities;

namespace Seller.DailyReport.Domain.Interfaces.Repository
{
    public interface IAccountingEntryRepository
    {
        Task<List<AccountingEntry>> GetAllOfTodayAsync();
    }
}
