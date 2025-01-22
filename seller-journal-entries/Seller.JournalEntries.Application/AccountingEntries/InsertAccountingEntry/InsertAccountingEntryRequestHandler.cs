using FluentResults;
using FluentValidation;
using MediatR;
using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Interfaces.Repository;

namespace Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry
{
    public class InsertAccountingEntryRequestHandler : IRequestHandler<InsertAccountingEntryRequest, Result<InsertAccountingEntryResponse>>
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly IValidator<InsertAccountingEntryRequest> _validator;

        public InsertAccountingEntryRequestHandler(IValidator<InsertAccountingEntryRequest> validator, IAccountingEntryRepository repository)
            => (_repository, _validator) = (repository, validator);

        public async Task<Result<InsertAccountingEntryResponse>> Handle(InsertAccountingEntryRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var accountingEntry = new AccountingEntry
                (
                id: Guid.NewGuid(),
                request.Description,
                request.MonetaryValue,
                request.EntryType,
                request.Date
                );

            await _repository.CreateAsync(accountingEntry);

            InsertAccountingEntryResponse insertAccountingEntryResponse = accountingEntry;
            return Result.Ok(insertAccountingEntryResponse);
        }
    }
}
