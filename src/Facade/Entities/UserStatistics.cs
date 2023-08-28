namespace Facade.Entities;

internal record UserStatistics(
    string UserId,
    DateTime? LastLoginAt
);