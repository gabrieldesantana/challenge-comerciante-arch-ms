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
            // connect to postgres with connection string from app settings

            var connectionString = _configuration.GetConnectionString("Database") ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Seller.JournalEntries.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
