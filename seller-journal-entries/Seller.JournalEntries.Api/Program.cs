using Microsoft.EntityFrameworkCore;
using Seller.JournalEntries.Api.Endpoints;
using Seller.JournalEntries.Api.Extensions;
using Seller.JournalEntries.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();
builder.RegisterApplicationServices();
builder.RegisterInfrastuctureServices();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await using var db = scope.ServiceProvider.GetService<AppDbContext>();
await db.Database.MigrateAsync();

app.RegisterMiddlewares();

app.RegisterAccountingEntryEndpoints();

app.Run();
