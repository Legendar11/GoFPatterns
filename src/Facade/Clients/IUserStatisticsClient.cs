using Facade.Clients.Models;

namespace Facade.Clients;

internal interface IUserStatisticsClient
{
    Task<UserStatisticsResponse> GetUserStatistics(string userId, CancellationToken cancellationToken = default);
}
