using FluentResults;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Interfaces.Repository;
using Seller.JournalEntries.Domain.Interfaces.Services;

namespace Seller.JournalEntries.Application.AccountingEntries.SelectAllAccountingEntries
{
    public class SelectAllAccountingEntriesRequestHandler : IRequestHandler<SelectAllAccountingEntriesRequest, Result<SelectAllAccountingEntriesResponse>>
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly ICacheService _cacheService;
        private const string CACHE_KEY = "AllAccountingEntries";
        private readonly ILogger<SelectAllAccountingEntriesRequestHandler> _logger;

        public SelectAllAccountingEntriesRequestHandler(
            IAccountingEntryRepository repository,
            ICacheService cacheService,
            ILogger<SelectAllAccountingEntriesRequestHandler> logger)
        {
            (_repository, _cacheService, _logger) = (repository, cacheService, logger);
        }

        public async Task<Result<SelectAllAccountingEntriesResponse>> Handle(SelectAllAccountingEntriesRequest request, CancellationToken cancellationToken)
        {
            var accountingEntries = _cacheService.GetByKey<List<AccountingEntry>>(CACHE_KEY);

            if (accountingEntries is null) 
            {
                accountingEntries = await _repository.GetAllAsync();
                _logger.LogInformation(">>>>> Consulta a base de dados <<<<<");

                _cacheService.Save(CACHE_KEY, accountingEntries);
            }

            SelectAllAccountingEntriesResponse response = accountingEntries;

            return Result.Ok(response);
        }

        private MemoryCacheEntryOptions SetCacheOptions() =>
            new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
    }
}
