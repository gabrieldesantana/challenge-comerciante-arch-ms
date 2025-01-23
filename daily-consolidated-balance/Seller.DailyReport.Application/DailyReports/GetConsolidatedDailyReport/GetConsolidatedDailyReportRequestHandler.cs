using FluentResults;
using MediatR;
using Seller.DailyReport.Domain.Interfaces.Repository;

namespace Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport
{
    public class GetConsolidatedDailyReportRequestHandler : IRequestHandler<GetConsolidatedDailyReportRequest, Result<GetConsolidatedDailyReportResponse>>
    {
        private readonly IAccountingEntryRepository _repository;

        public GetConsolidatedDailyReportRequestHandler(IAccountingEntryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<GetConsolidatedDailyReportResponse>> Handle(GetConsolidatedDailyReportRequest request, CancellationToken cancellationToken)
        {
            var accountingEntriesOfToday =  await _repository.GetAllOfTodayAsync();

            if (!accountingEntriesOfToday.Any())
                return Result.Ok(new GetConsolidatedDailyReportResponse());

            var response = new GetConsolidatedDailyReportResponse().FormatResponse(accountingEntriesOfToday);
            return Result.Ok(response);
        }
    }
}
