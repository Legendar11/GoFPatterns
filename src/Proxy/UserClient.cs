using Serilog;
using System.Text.Json;

namespace Proxy;

/// <summary>
/// Default implementation of interface sends the http request.
/// </summary>
internal class UserClient : IUserClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public UserClient(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users", cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        var users = JsonSerializer.Deserialize<IReadOnlyCollection<User>>(responseContent);
        _logger.Information("Data from http client");

        _ = users ?? throw new NullReferenceException("Data from  Users client is null");
        return users;
    }
}
