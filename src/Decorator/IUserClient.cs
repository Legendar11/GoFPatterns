using Decorator.Entities;

namespace Decorator;

/// <summary>
/// Interface is the same for decorator and decorated service.
/// </summary>
internal interface IUserClient
{
    Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default);
}
