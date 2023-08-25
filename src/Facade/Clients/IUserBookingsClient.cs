using Facade.Clients.Models;

namespace Facade.Clients;

internal interface IUserBookingsClient
{
    Task<UserBookingsResponse> GetUserBookingsAsync(string userId, CancellationToken cancellationToken = default);
}
