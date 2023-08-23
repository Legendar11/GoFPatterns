using Decorator.Entities;
using Serilog;
using System.Text.RegularExpressions;

namespace Decorator.Decorators;

/// <summary>
/// Dectorator for sanitize users data
/// </summary>
internal partial class SanitizeDecorator : AbstractDecorator
{
    public SanitizeDecorator(IUserClient userClient, ILogger logger) : base(userClient, logger)
    {
    }

    public override async Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await base.GetUsersAsync(cancellationToken);

        var regex = GetRegexForSanitize();
        foreach (var user in users)
        {
            user.Username = regex.Replace(user.Username, _ => string.Empty);
        }

        _logger.Information("SanitizeDecorator was executed");

        return users;
    }

    [GeneratedRegex("[^\\u0000-\\u007F]+", RegexOptions.Compiled | RegexOptions.Singleline)]
    private static partial Regex GetRegexForSanitize();
}
