using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Seller.DailyReport.Application;
using Seller.DailyReport.Domain.Interfaces.Repository;
using Seller.DailyReport.Infrastructure.Data.Context;
using Seller.DailyReport.Infrastructure.Data.Repository;
using System;

namespace Seller.DailyReport.Api.Extensions
{
    public static class Configurations
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationEntryPoint).Assembly));

            builder.Services.AddValidatorsFromAssembly(typeof(ApplicationEntryPoint).Assembly);

            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            builder.Services.AddScoped<IAccountingEntryRepository, AccountingEntryRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
