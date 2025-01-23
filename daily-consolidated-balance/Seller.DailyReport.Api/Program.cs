using Seller.DailyReport.Api.Endpoints;
using Seller.DailyReport.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterDailyReportsEndpoints();

app.Run();
