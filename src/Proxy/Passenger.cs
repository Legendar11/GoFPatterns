using System.Text.Json.Serialization;

namespace Proxy;

internal class Passenger
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set;} = null!;
}
