using FluentResults;
using MediatR;

namespace Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport
{
    public record GetConsolidatedDailyReportRequest() : IRequest<Result<GetConsolidatedDailyReportResponse>>;
}
