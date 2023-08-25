namespace Facade.Entities;

internal record UserMetadata
{
    public string UserId { get; init; } = null!;

    public Dictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
