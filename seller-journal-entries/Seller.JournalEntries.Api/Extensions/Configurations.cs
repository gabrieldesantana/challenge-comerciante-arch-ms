﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Seller.JournalEntries.Application;
using Seller.JournalEntries.Domain.Interfaces.Repository;
using Seller.JournalEntries.Infrastructure.Data.Context;
using Seller.JournalEntries.Infrastructure.Data.Repository;

namespace Seller.JournalEntries.Api.Extensions
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
            using var scope = app.Services.CreateAsyncScope();
            using var db = scope.ServiceProvider.GetService<AppDbContext>();
            db.Database.MigrateAsync();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
