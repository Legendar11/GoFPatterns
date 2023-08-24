namespace Adapter;

/// <summary>
/// Adapted interface returns still correct but adapted to use data.
/// </summary>
internal interface ILogClientAdapter
{
    Task<DateTime?> GetLastLoginAsync(string userId, CancellationToken cancellationToken = default);

    Task<DateTime?> GetLastResetPassword(string userId, CancellationToken cancellationToken = default);
}
