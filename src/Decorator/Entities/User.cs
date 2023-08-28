using System.Text.Json.Serialization;

namespace Decorator.Entities;

internal record User
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonIgnore]
    public UserMetadata Metadata { get; set; } = new UserMetadata();
}
