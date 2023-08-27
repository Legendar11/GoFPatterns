namespace Flyweight;

/// <summary>
/// Concrete flyweight,
/// keeps reference for inner state.
/// </summary>
internal record AirplaneFlyweight(
    AirplaneShared Shared
) : IAirplaneFlyweight
{
    public void DisplayFullInfo(AirplaneUnique data)
    {
        Console.WriteLine($"""

            {nameof(AirplaneShared.Country)}: {Shared.Country}
            {nameof(AirplaneShared.Type)}: {Shared.Type}
            -------------------------------------------
            {nameof(AirplaneUnique.Color)}: {data.Color}
            {nameof(AirplaneUnique.CrewNames)}: {string.Join(", ", data.CrewNames)}

            =====================//======================

        """);
    }
}
