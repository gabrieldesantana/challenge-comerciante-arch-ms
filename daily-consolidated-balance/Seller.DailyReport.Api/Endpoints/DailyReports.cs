using MediatR;
using Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport;

namespace Seller.DailyReport.Api.Endpoints
{
    public static class DailyReports
    {
        public static void RegisterDailyReportsEndpoints(this IEndpointRouteBuilder routes)
        {
            var dailyReports = routes.MapGroup("/api/v1/dailyReports");

            dailyReports.MapGet("", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetConsolidatedDailyReportRequest());

                return response.IsSuccess
                ? Results.Ok(response.Value)
                : Results.BadRequest(response.Errors);
            })
            .Produces(200, typeof(GetConsolidatedDailyReportResponse))
            .Produces(400)
            .WithName("GetConsolidatedDailyReport")
            .WithOpenApi();
        }
    }
}
