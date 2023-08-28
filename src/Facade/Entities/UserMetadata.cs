namespace Facade.Entities;

internal record UserMetadata(
    string UserId,
    Dictionary<string, string> Metadata
);
