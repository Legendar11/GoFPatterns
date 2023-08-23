using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Proxy;

/// <summary>
/// Enhanced implementation of interface tries to take data from cache,
/// in case cache is empty - delegate work to real serving object.
/// </summary>
internal class CachedUserClient : IUserClient
{
    // Proxy implements additional functionality regarding cache mechanism
    private readonly IMemoryCache _cache;

    // Proxy keeps reference to original implementation.
    private readonly Lazy<UserClient> _usersClient;
    private readonly ILogger _logger;

    private const string CacheKey = "users";

    public CachedUserClient(IMemoryCache cache, HttpClient httpClient, ILogger logger)
    {
        _cache = cache;
        _logger = logger;

        // Proxy controls service object 
        _usersClient = new Lazy<UserClient>(() => new UserClient(httpClient, logger));
    }

    public async Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        // Proxy tries to get data from cache before call real service object
        if (_cache.TryGetValue(CacheKey, out IReadOnlyCollection<User>? cachedUsers)
            && cachedUsers is not null)
        {
            _logger.Information("Data from cache");
            return cachedUsers;
        }

        var users = await _usersClient.Value.GetUsersAsync(cancellationToken);

        // Proxy put data in cache after call real service object
        _cache.Set(CacheKey, users, TimeSpan.FromSeconds(5));

        return users;
    }
}
