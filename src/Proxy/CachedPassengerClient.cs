using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Proxy;

/// <summary>
/// Enhanced implementation of interface tries to take data from cache,
/// in case cache is empty - delegate work to real serving object.
/// </summary>
internal class CachedPassengerClient : IPassengerClient
{
    // Proxy implements additional functionality regarding cache mechanism
    private readonly IMemoryCache _cache;

    // Proxy keeps reference to original implementation.
    private readonly Lazy<PassengerClient> _passengerClient;
    private readonly ILogger _logger;

    private const string CacheKey = "passengers";

    public CachedPassengerClient(IMemoryCache cache, HttpClient httpClient, ILogger logger)
    {
        _cache = cache;
        _logger = logger;

        // Proxy controls service object 
        _passengerClient = new Lazy<PassengerClient>(() => new PassengerClient(httpClient, logger));
    }

    public async Task<IReadOnlyCollection<Passenger>?> GetPassengersAsync(CancellationToken cancellationToken = default)
    {
        // Proxy tries to get data from cache before call real service object
        if (_cache.TryGetValue(CacheKey, out IReadOnlyCollection<Passenger>? cachedPassengers))
        {
            _logger.Information("Data from cache");
            return cachedPassengers;
        }

        var passengers = await _passengerClient.Value.GetPassengersAsync(cancellationToken);

        // Proxy put data in cache after call real service object
        _cache.Set(CacheKey, passengers, TimeSpan.FromSeconds(5));

        return passengers;
    }
}
