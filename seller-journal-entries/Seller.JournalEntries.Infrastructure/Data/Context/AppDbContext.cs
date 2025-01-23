using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seller.JournalEntries.Domain.Entities;

namespace Seller.JournalEntries.Infrastructure.Data.Context
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
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") ?? _configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Seller.JournalEntries.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
