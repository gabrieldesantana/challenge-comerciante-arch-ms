using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Seller.DailyReport.Application;
using Seller.DailyReport.Application.Services;
using Seller.DailyReport.Domain.Interfaces.Repository;
using Seller.DailyReport.Domain.Interfaces.Services;
using Seller.DailyReport.Infrastructure.Data.Context;
using Seller.DailyReport.Infrastructure.Data.Repository;
using System;

namespace Seller.DailyReport.Api.Extensions
{
    public static class Configurations
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ICacheService, CacheService>();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }

        public static void RegisterApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationEntryPoint).Assembly));
            builder.Services.AddValidatorsFromAssembly(typeof(ApplicationEntryPoint).Assembly);
        }

        public static void RegisterInfrastuctureServices(this WebApplicationBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IAccountingEntryRepository, AccountingEntryRepository>();
        }
    }
}
