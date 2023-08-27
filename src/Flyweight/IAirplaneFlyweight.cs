namespace Flyweight;

/// <summary>
/// Flyweight interface - we need to execute operation with extrinsic state.
/// </summary>
internal interface IAirplaneFlyweight
{
    void DisplayFullInfo(AirplaneUnique unique);
}
