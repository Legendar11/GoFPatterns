namespace Flyweight;

/// <summary>
/// Factory for flyweights.
/// </summary>
internal interface IAirplaneFlyweightFactory
{
    AirplaneFlyweight GetAirplaneFlyweight(AirplaneShared airplane);
}
