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
            .WithName("GetConsolidatedDailyReport")
            .WithOpenApi();
        }
    }
    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
