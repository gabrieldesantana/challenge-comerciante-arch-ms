using MediatR;
using Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry;
using Seller.JournalEntries.Application.AccountingEntries.SelectAccountingEntryById;
using Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries;

namespace Seller.JournalEntries.Api.Endpoints
{
    public static class AccountingEntries
    {
        public static void RegisterAccountingEntryEndpoints(this IEndpointRouteBuilder routes)
        {
            var accountingEntries = routes.MapGroup("/api/v1/accountingEntries");

            accountingEntries.MapGet("", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new SelectAllAccountingEntriesRequest());

                return response.IsSuccess
                ? Results.Ok(response.Value)
                : Results.BadRequest(response.Errors);
            })
            .Produces(200, typeof(SelectAllAccountingEntriesResponse))
            .Produces(400)
            .WithName("GetAllAccountingEntries")
            .WithOpenApi();

            accountingEntries.MapGet("{id}", async (IMediator mediator, Guid id) =>
            {
                var response = await mediator.Send(new SelectAccountingEntryByIdRequest(id));

                return response.IsSuccess
                ? Results.Ok(response.Value)
                : Results.BadRequest(response.Errors);
            })
            .Produces(200, typeof(SelectAccountingEntryByIdResponse))
            .Produces(400)
            .WithName("GetAccountingEntryById")
            .WithOpenApi();

            accountingEntries.MapPost("", async (IMediator mediator, InsertAccountingEntryRequest request) =>
            {
                var response = await mediator.Send(request);

                return response.IsSuccess
                ? Results.Ok(response.Value)
                : Results.BadRequest(response.Errors);
            })
            .Produces(200, typeof(InsertAccountingEntryResponse))
            .Produces(400)
            .WithName("PostAccountingEntry")
            .WithOpenApi();
        }
    }

}
