using Facade.Entities;

namespace Facade;

/// <summary>
/// Facade for user fetching.
/// </summary>
internal interface IUserService
{
    Task<User> GetUser(string userId, CancellationToken cancellationToken = default);
}
