using FluentResults;
using FluentValidation;
using MediatR;
using Seller.JournalEntries.Domain.Interfaces.Repository;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAccountingEntryById
{
    public class SelectAccountingEntryByIdRequestHandler : IRequestHandler<SelectAccountingEntryByIdRequest, Result<SelectAccountingEntryByIdResponse>>
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly IValidator<SelectAccountingEntryByIdRequest> _validator;
        public SelectAccountingEntryByIdRequestHandler(IAccountingEntryRepository repository, IValidator<SelectAccountingEntryByIdRequest> validator)
            => (_repository, _validator) = (repository, validator);
        public async Task<Result<SelectAccountingEntryByIdResponse>> Handle(SelectAccountingEntryByIdRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var accountingEntry = await _repository.GetByIdAsync(request.Id);

            SelectAccountingEntryByIdResponse response = accountingEntry;

            return Result.Ok(response);
        }
    }
}
