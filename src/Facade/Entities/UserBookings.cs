namespace Facade.Entities;

internal record UserBookings(
    string UserId,
    IReadOnlyCollection<string> BookingsId
);
