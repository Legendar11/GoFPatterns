namespace Prototype;

internal class Airplane : ICloneable
{
    public int SeatsCount { get; set; } = 0;

    public string Name { get; set; } = null!;

    public List<Passenger> Passengers { get; set; } = new List<Passenger>();

    public object Clone() => DeepClone();

    // Shallow copy, set all values as is
    public Airplane ShallowClone() =>
        // we can use MemberwiseClone() for coping value type members
        new()
        {
            Name = Name,
            SeatsCount = SeatsCount,
            Passengers = Passengers
        };

    // Deep copy, set all values as is
    // but provide coping for dependendable objects
    public Airplane DeepClone() =>
        new()
        {
            Name = Name,
            SeatsCount = SeatsCount,
            Passengers = Passengers.Select(x => (Passenger)x.Clone()).ToList()
        };

    public override string ToString()
    {
        return $"""

            Airplane has:
                Name: {Name}
                Seats: {SeatsCount}
                Passengers: {string.Join(", ", Passengers.Select(x => x.Name))}

        """;
    }
}
