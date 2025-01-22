#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Seller.JournalEntries.Api/Seller.JournalEntries.Api.csproj", "Seller.JournalEntries.Api/"]
COPY ["Seller.JournalEntries.Application/Seller.JournalEntries.Application.csproj", "Seller.JournalEntries.Application/"]
COPY ["Seller.JournalEntries.Domain/Seller.JournalEntries.Domain.csproj", "Seller.JournalEntries.Domain/"]
COPY ["Seller.JournalEntries.Infrastructure/Seller.JournalEntries.Infrastructure.csproj", "Seller.JournalEntries.Infrastructure/"]
RUN dotnet restore "./Seller.JournalEntries.Api/Seller.JournalEntries.Api.csproj"
COPY . .
WORKDIR "/src/Seller.JournalEntries.Api"
RUN dotnet build "./Seller.JournalEntries.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Seller.JournalEntries.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seller.JournalEntries.Api.dll"]