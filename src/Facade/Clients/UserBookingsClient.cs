using Facade.Clients.Models;

namespace Facade.Clients;

internal class UserBookingsClient : IUserBookingsClient
{
    public Task<UserBookingsResponse> GetUserBookingsAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new UserBookingsResponse
        {
            UserId = userId,
            BookingsIds = Enumerable.Range(1, 10).Select(i => Guid.NewGuid().ToString()).ToArray()
        });
    }
}
