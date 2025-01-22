using FluentResults;
using MediatR;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAccountingEntryById
{
    public record SelectAccountingEntryByIdRequest(Guid Id) : IRequest<Result<SelectAccountingEntryByIdResponse>>;
}
