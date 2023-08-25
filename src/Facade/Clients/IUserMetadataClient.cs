using Facade.Clients.Models;

namespace Facade.Clients;

internal interface IUserMetadataClient
{
    Task<UserMetadataResponse> GetUserMetadataAsync(string userId, CancellationToken cancellationToken = default);
}
