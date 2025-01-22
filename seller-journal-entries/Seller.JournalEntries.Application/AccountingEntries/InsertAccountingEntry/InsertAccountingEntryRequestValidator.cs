using FluentValidation;

namespace Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry
{
    public sealed class InsertAccountingEntryRequestValidator : AbstractValidator<InsertAccountingEntryRequest>
    {
        public InsertAccountingEntryRequestValidator()
        {
            RuleFor(v => v.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(v => v.MonetaryValue)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(v => v.EntryType)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(v => v.Date)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
