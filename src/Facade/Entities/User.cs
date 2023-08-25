namespace Facade.Entities;

internal record User
{
    public string Id { get; init; } = null!;

    public bool HasBookings { get; init; }

    public DateTime? LastLoginAt { get; init; }

    public bool HasAvatar { get; init; }

    public string? Phone { get; init; }
}
