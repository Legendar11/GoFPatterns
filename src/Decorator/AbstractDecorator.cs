using Decorator.Entities;
using Serilog;

namespace Decorator;

/// <summary>
/// Abstract decorator implements default behaviour
/// and contains a reference for decorated service.
/// </summary>
internal abstract class AbstractDecorator : IUserClient
{
    protected readonly IUserClient _decorated;
    protected readonly ILogger _logger;

    public AbstractDecorator(IUserClient userClient, ILogger logger)
    {
        _decorated = userClient;
        _logger = logger;
    }

    public virtual Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        return _decorated.GetUsersAsync(cancellationToken);
    }
}
