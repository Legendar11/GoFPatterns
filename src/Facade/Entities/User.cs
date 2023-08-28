namespace Facade.Entities;

internal record User(
    string Id,
    bool HasBookings,
    DateTime? LastLoginAt,
    bool HasAvatar,
    string? Phone
);