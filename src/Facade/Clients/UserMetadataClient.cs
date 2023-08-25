using Facade.Clients.Models;

namespace Facade.Clients;

internal class UserMetadataClient : IUserMetadataClient
{
    public Task<UserMetadataResponse> GetUserMetadataAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new UserMetadataResponse
        {
            UserId = userId,
            Metadata = new Dictionary<string, object>
            {
                ["avatar_id"] = Guid.NewGuid().ToString(),
                ["phone"] = "9781353113551"
            }
        });
    }
}
