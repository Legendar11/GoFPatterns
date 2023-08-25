namespace Facade.Clients.Models;

internal record UserBookingsResponse
{
    public string? UserId { get; init; } = null!;

    public IReadOnlyCollection<string> BookingsIds { get; init; } = new List<string>();
}
