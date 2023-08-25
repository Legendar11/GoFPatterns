using Facade.Clients.Models;

namespace Facade.Clients;

internal class UserStatisticsClient : IUserStatisticsClient
{
    public Task<UserStatisticsResponse> GetUserStatistics(string userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new UserStatisticsResponse
        {
            UserId = userId,
            FirstBookingAt = DateTime.UtcNow.AddDays(-10),
            LastBookingAt = DateTime.UtcNow.AddDays(-5),
        });
    }
}
