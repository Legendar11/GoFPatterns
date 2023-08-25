namespace Facade.Entities;

internal record UserBookings
{
    public string UserId { get; init; } = null!;

    public IReadOnlyCollection<string> BookingsId { get; init; } = null!;
}
