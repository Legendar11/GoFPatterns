using Facade.Clients;
using Facade.Entities;

namespace Facade;

/// <summary>
/// Facade keeps references to all inner sub-modules,
/// it allowes to handle all necessary dependencies in one place.
/// </summary>
internal class UserService : IUserService
{
    private readonly IUserBookingsClient _userBookingsClient;
    private readonly IUserMetadataClient _userMetadataClient;
    private readonly IUserStatisticsClient _userStatisticsClient;

    public UserService(
        IUserBookingsClient userBookingsClient,
        IUserMetadataClient userMetadataClient,
        IUserStatisticsClient userStatisticsClient)
    {
        // Currently we get dependencies via constructor,
        // but Facade pattern may be obligated to instantiate dependencies by itself
        _userBookingsClient = userBookingsClient;
        _userMetadataClient = userMetadataClient;
        _userStatisticsClient = userStatisticsClient;
    }

    public async Task<User> GetUser(string userId, CancellationToken cancellationToken = default)
    {
        // Encapsulate all complex logic in Facade method
        var metadataTask = _userMetadataClient.GetUserMetadataAsync(userId, cancellationToken);
        var statisticsTask = _userStatisticsClient.GetUserStatistics(userId, cancellationToken);
        var bookingsTask = _userBookingsClient.GetUserBookingsAsync(userId, cancellationToken);

        await Task.WhenAll(metadataTask, statisticsTask, bookingsTask);

        return new User
        {
            Id = userId,
            HasAvatar = metadataTask.Result.Metadata.ContainsKey("avatar_id"),
            Phone = metadataTask.Result.Metadata.TryGetValue("phone", out var phone) ? (string)phone : null,
            LastLoginAt = statisticsTask.Result.LastBookingAt,
            HasBookings = bookingsTask.Result.BookingsIds.Any()
        };
    }
}
