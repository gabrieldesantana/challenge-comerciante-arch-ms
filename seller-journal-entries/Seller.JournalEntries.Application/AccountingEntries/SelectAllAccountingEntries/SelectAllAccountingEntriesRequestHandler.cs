using FluentResults;
using MediatR;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries
{
    public class SelectAllAccountingEntriesRequestHandler : IRequestHandler<SelectAllAccountingEntriesRequest, Result<SelectAllAccountingEntriesResponse>>
    {
        public Task<Result<SelectAllAccountingEntriesResponse>> Handle(SelectAllAccountingEntriesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
