namespace Composite;

/// <summary>
/// User is a leaf component -
/// it can implement <see cref="IStatistics.GetLastDateOfLogin"/> by itself.
/// </summary>
internal class User : IStatistics
{
    public DateTime LastLoginAt { get; init; }

    public DateTime GetLastDateOfLogin() => LastLoginAt;
}
