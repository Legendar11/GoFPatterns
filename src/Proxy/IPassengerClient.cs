namespace Proxy;

/// <summary>
/// Interface is the same for proxy and original version of service.
/// </summary>
internal interface IPassengerClient
{
    Task<IReadOnlyCollection<Passenger>?> GetPassengersAsync(CancellationToken cancellationToken = default);
}
