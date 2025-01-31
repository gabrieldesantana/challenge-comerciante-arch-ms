using FluentResults;
using MediatR;
using Seller.DailyReport.Domain.Entities;
using Seller.DailyReport.Domain.Interfaces.Repository;
using Seller.DailyReport.Domain.Interfaces.Services;

namespace Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport
{
    public class GetConsolidatedDailyReportRequestHandler : IRequestHandler<GetConsolidatedDailyReportRequest, Result<GetConsolidatedDailyReportResponse>>
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly ICacheService _cacheService;
        private const string CACHE_KEY = "AccountingEntriesOfToday";

        public GetConsolidatedDailyReportRequestHandler(IAccountingEntryRepository repository, ICacheService cacheService)
            => (_repository,_cacheService) = (repository, cacheService);

        public async Task<Result<GetConsolidatedDailyReportResponse>> Handle(GetConsolidatedDailyReportRequest request, CancellationToken cancellationToken)
        {
            var accountingEntriesOfToday = _cacheService.GetByKey<List<AccountingEntry>>(CACHE_KEY);

            if (accountingEntriesOfToday is null)
            {
                accountingEntriesOfToday = await _repository.GetAllOfTodayAsync();
                _cacheService.Save(CACHE_KEY, accountingEntriesOfToday);
            }

            if (!accountingEntriesOfToday.Any())
                return Result.Ok(new GetConsolidatedDailyReportResponse() { Date = DateTime.Today});

            var response = new GetConsolidatedDailyReportResponse().FormatResponse(accountingEntriesOfToday);
            return Result.Ok(response);
        }
    }
}
