FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Seller.JournalEntries.Api/Seller.JournalEntries.Api.csproj", "Seller.JournalEntries.Api/"]
COPY ["Seller.JournalEntries.Application/Seller.JournalEntries.Application.csproj", "Seller.JournalEntries.Application/"]
COPY ["Seller.JournalEntries.Domain/Seller.JournalEntries.Domain.csproj", "Seller.JournalEntries.Domain/"]
COPY ["Seller.JournalEntries.CrossCutting/Seller.JournalEntries.CrossCutting.csproj", "Seller.JournalEntries.CrossCutting/"]
COPY ["Seller.JournalEntries.Infrastructure/Seller.JournalEntries.Infrastructure.csproj", "Seller.JournalEntries.Infrastructure/"]
RUN dotnet restore -a "./Seller.JournalEntries.Api/Seller.JournalEntries.Api.csproj"
COPY . .
WORKDIR "/src/Seller.JournalEntries.Api"
RUN dotnet build "Seller.JournalEntries.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Seller.JournalEntries.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seller.JournalEntries.Api.dll"]