using FluentResults;
using MediatR;
using Seller.JournalEntries.Domain.Interfaces.Repository;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries
{
    public class SelectAllAccountingEntriesRequestHandler : IRequestHandler<SelectAllAccountingEntriesRequest, Result<SelectAllAccountingEntriesResponse>>
    {
        private readonly IAccountingEntryRepository _repository;

        public SelectAllAccountingEntriesRequestHandler(IAccountingEntryRepository repository)
            => (_repository) = (repository);

        public async Task<Result<SelectAllAccountingEntriesResponse>> Handle(SelectAllAccountingEntriesRequest request, CancellationToken cancellationToken)
        {
            var accountingEntries = await _repository.GetAllAsync();

            SelectAllAccountingEntriesResponse response = accountingEntries;

            return Result.Ok(response);
        }
    }
}
