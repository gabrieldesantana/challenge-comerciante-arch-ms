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
                await mediator.Send(new SelectAllAccountingEntriesRequest());
            })
            .WithName("GetAllAccountingEntries")
            .WithOpenApi();

            accountingEntries.MapGet("{id}", async (IMediator mediator, Guid id) =>
            {
                await mediator.Send(new SelectAccountingEntryByIdRequest(id));
            })
            .WithName("GetAccountingEntryById")
            .WithOpenApi();

            accountingEntries.MapPost("", async (IMediator mediator, InsertAccountingEntryRequest request) =>
            {
                var result = await mediator.Send(request);
                return result;
            })
            .WithName("PostAccountingEntry")
            .WithOpenApi();
        }
    }

}
