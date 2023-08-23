using Decorator.Entities;
using Serilog;

namespace Decorator.Decorators;

/// <summary>
/// Decorator for providing metadata for users
/// </summary>
internal class UserMetadataDecorator : AbstractDecorator
{
    public UserMetadataDecorator(IUserClient userClient, ILogger logger) : base(userClient, logger)
    {
    }

    public override async Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await base.GetUsersAsync(cancellationToken);

        foreach (var user in users)
        {
            user.Metadata.Add("UserMetadata_Exist", true);
        }

        _logger.Information("UserMetadataDecorator was executed");

        return users;
    }
}
