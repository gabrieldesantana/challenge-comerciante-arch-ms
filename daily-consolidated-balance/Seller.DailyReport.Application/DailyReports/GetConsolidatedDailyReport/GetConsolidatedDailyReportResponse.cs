using Seller.DailyReport.Domain.Entities;

namespace Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport
{
    public class GetConsolidatedDailyReportResponse()
    {
        public DateTime Date { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalConsolidated { get; set; }
        public List<AccountingEntry> Debits { get; set; }
        public List<AccountingEntry> Credits { get; set; }

        public GetConsolidatedDailyReportResponse FormatResponse(List<AccountingEntry> accountingEntries)
        {
            var date = accountingEntries.First().Date.Date;
            var credits = accountingEntries.Where(a => a.Type == Domain.Enums.EEntryType.Credit).ToList();
            var totalCredit = credits.Sum(a => a.MonetaryValue);
            var debits = accountingEntries.Where(a => a.Type == Domain.Enums.EEntryType.Debit).ToList();
            var totalDebit = debits.Sum(a => a.MonetaryValue);

            return new GetConsolidatedDailyReportResponse()
            {
                Date = date,
                TotalDebit = totalDebit,
                TotalCredit = totalCredit,
                TotalConsolidated = (totalCredit - totalDebit),
                Debits = debits,
                Credits = credits
            };
        }
    }
}
