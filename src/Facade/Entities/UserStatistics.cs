namespace Facade.Entities;

internal record UserStatistics
{
    public string UserId { get; init; } = null!;

    public DateTime? LastLoginAt { get; init; } = null!;
}
