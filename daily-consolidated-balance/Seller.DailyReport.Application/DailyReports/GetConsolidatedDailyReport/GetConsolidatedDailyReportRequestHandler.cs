using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetConsolidatedDailyReportRequestHandler> _logger;

        public GetConsolidatedDailyReportRequestHandler(
            IAccountingEntryRepository repository,
            ICacheService cacheService,
            ILogger<GetConsolidatedDailyReportRequestHandler> logger)
            => (_repository,_cacheService, _logger) = (repository, cacheService, logger);

        public async Task<Result<GetConsolidatedDailyReportResponse>> Handle(GetConsolidatedDailyReportRequest request, CancellationToken cancellationToken)
        {
            var accountingEntriesOfTodayTask = GetCachedDataAsync();
            var accountingEntriesOfToday = await accountingEntriesOfTodayTask;

            if (!accountingEntriesOfToday.Any())
                return Result.Ok(new GetConsolidatedDailyReportResponse() { Date = DateTime.Today});

            var response = new GetConsolidatedDailyReportResponse().FormatResponse(accountingEntriesOfToday);
            return Result.Ok(response);
        }

        private async ValueTask<List<AccountingEntry>> GetCachedDataAsync()
        {
            var accountingEntriesOfToday = _cacheService.GetByKey<List<AccountingEntry>>(CACHE_KEY);

            if (accountingEntriesOfToday is null)
            {
                accountingEntriesOfToday = await _repository.GetAllOfTodayAsync();
                _logger.LogInformation(">>>>> Consulta a base de dados <<<<<");
                _cacheService.Save(CACHE_KEY, accountingEntriesOfToday);
            }

            return accountingEntriesOfToday;
        }
    }
}
