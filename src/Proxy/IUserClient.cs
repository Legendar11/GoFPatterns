namespace Proxy;

/// <summary>
/// Interface is the same for proxy and original version of service.
/// </summary>
internal interface IUserClient
{
    Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default);
}
