using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seller.JournalEntries.Domain.Entities;

namespace Seller.JournalEntries.Infrastructure.Data.Configurations
{
    public class AccountingEntryEntityTypeConfiguration : IEntityTypeConfiguration<AccountingEntry>
    {
        public void Configure(EntityTypeBuilder<AccountingEntry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("JournalEntries");
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
        }
    }
}
