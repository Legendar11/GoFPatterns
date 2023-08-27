namespace Flyweight;

/// <summary>
/// Factory for flyweights:
/// for each <see cref="GetAirplaneFlyweight"/>
/// factory will try to return cached version.
/// </summary>
internal class AirplaneFlyweightFactory : IAirplaneFlyweightFactory
{
    private readonly Dictionary<string, IAirplaneFlyweight> _cache = new();

    public AirplaneFlyweightFactory(IEnumerable<AirplaneShared>? airplanes = null)
    {
        airplanes ??= Enumerable.Empty<AirplaneShared>();

        foreach (AirplaneShared airplane in airplanes)
        {
            _cache.Add(airplane.ToString(), new AirplaneFlyweight(airplane));
        }
    }

    public AirplaneFlyweight GetAirplaneFlyweight(AirplaneShared airplane)
    {
        string key = airplane.ToString();

        if (!_cache.ContainsKey(key))
        {
            _cache.Add(key, new AirplaneFlyweight(airplane));
            Console.WriteLine($"New entry is created in cache: {airplane}");
        }
        else
        {
            Console.WriteLine($"Get existing key from cache: {airplane}");
        }

        return (AirplaneFlyweight)_cache[key]!;
    }
}
