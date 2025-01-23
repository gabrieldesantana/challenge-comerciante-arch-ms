FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Seller.DailyReport.Api/Seller.DailyReport.Api.csproj", "Seller.DailyReport.Api/"]
COPY ["Seller.DailyReport.Application/Seller.DailyReport.Application.csproj", "Seller.DailyReport.Application/"]
COPY ["Seller.DailyReport.Domain/Seller.DailyReport.Domain.csproj", "Seller.DailyReport.Domain/"]
COPY ["Seller.DailyReport.Infrastructure/Seller.DailyReport.Infrastructure.csproj", "Seller.DailyReport.Infrastructure/"]
RUN dotnet restore "./Seller.DailyReport.Api/Seller.DailyReport.Api.csproj"
COPY . .
WORKDIR "/src/Seller.DailyReport.Api"
RUN dotnet build "./Seller.DailyReport.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Seller.DailyReport.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seller.DailyReport.Api.dll"]