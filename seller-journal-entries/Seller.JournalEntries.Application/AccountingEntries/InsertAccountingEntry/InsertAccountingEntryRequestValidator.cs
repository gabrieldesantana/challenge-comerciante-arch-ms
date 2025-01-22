using FluentValidation;
using Seller.JournalEntries.Domain.Enums;

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
                .GreaterThan(0)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(v => v.EntryType)
                .IsInEnum()
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");

            RuleFor(v => v.Date)
                .LessThanOrEqualTo(DateTime.Now)
                .NotNull()
                .WithMessage("{PropertyName} deve ser informado");
        }
    }
}
