namespace Facade.Clients.Models;

internal record UserMetadataResponse
{
    public string? UserId { get; init; } = null!;
    public Dictionary<string, object> Metadata { get; init; } = new Dictionary<string, object>();
}
