using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seller.DailyReport.Domain.Entities;

namespace Seller.DailyReport.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<AccountingEntry> JournalEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Seller.JournalEntries.Infrastructure"));
        }
    }
}
