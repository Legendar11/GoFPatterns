namespace Flyweight;

/// <summary>
/// Factory for flyweights.
/// </summary>
internal interface IAirplaneFlyweightFactory
{
    IAirplaneFlyweight GetAirplaneFlyweight(AirplaneShared airplane);
}
