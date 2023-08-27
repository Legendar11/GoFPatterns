namespace Flyweight;

/// <summary>
/// Inner state.
/// </summary>
internal readonly record struct AirplaneShared(
    string Type,
    string Country
);