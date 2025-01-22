using FluentResults;
using MediatR;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries
{
    public class SelectAllAccountingEntriesRequest()
        : IRequest<Result<SelectAllAccountingEntriesResponse>>;
}
