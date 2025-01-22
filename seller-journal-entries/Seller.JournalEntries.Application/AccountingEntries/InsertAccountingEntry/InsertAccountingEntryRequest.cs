using FluentResults;
using MediatR;
using Seller.JournalEntries.Domain.Enums;

namespace Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry
{
    public record InsertAccountingEntryRequest(string? Description, decimal MonetaryValue, EEntryType? EntryType, DateTime Date) 
        : IRequest<Result<InsertAccountingEntryResponse>>;
}
