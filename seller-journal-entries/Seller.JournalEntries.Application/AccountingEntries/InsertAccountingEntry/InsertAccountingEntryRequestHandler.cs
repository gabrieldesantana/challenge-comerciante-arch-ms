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
            var validate = _validator.Validate(request); //.ValidateAndThrow(request);

            if (!validate.IsValid)
                return Result.Fail(validate.ToString("~"));

            var accountingEntry = new AccountingEntry
                (
                request.Description,
                request.MonetaryValue,
                request.EntryType,
                request.Date
                );

            await _repository.CreateAsync(accountingEntry);

            InsertAccountingEntryResponse response = accountingEntry;
            return Result.Ok(response);
        }
    }
}
