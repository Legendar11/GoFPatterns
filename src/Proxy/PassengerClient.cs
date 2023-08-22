using Serilog;
using System.Text.Json;

namespace Proxy;

/// <summary>
/// Default implementation of interface sends the http request.
/// </summary>
internal class PassengerClient : IPassengerClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public PassengerClient(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<Passenger>?> GetPassengersAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users", cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        var passengers = JsonSerializer.Deserialize<IReadOnlyCollection<Passenger>>(responseContent);
        _logger.Information("Data from http client");

        return passengers;
    }
}
