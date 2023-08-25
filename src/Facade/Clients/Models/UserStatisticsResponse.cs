namespace Facade.Clients.Models;

internal record UserStatisticsResponse
{
    public string? UserId { get; init; } = null!;

    public DateTime? FirstBookingAt { get; init; } = null!;

    public DateTime? LastBookingAt { get; init; } = null!;
}
