using FluentValidation;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAccountingEntryById
{
    public sealed class SelectAccountingEntryByIdRequestValidator : AbstractValidator<SelectAccountingEntryByIdRequest>
    {
        public SelectAccountingEntryByIdRequestValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("{PropertyName} deve ser informado");
        }
    }
}
