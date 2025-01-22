using Seller.JournalEntries.Api.Endpoints;
using Seller.JournalEntries.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterAccountingEntryEndpoints();

app.Run();
