using Prototype;

// Gang of Four, Prototype:
// The prototype pattern is used to instantiate a new object
// by copying all of the properties of an existing object,
// creating an independent clone.
// This practise is particularly useful when
// the construction of a new object is inefficient.

var originalAirplane = new Airplane
{
    Name = "Airbus 310",
    SeatsCount = 560,
    Passengers = new List<Passenger>
    {
        new Passenger { Name = "John Smith" }
    }
};

var clonedAirplace = (Airplane)originalAirplane.Clone();

// Changes will not affect originalAirplane
clonedAirplace.SeatsCount = 300;
clonedAirplace.Passengers.Add(new Passenger { Name = "Bruce Wayne" });

Console.WriteLine($"Original airplace:{originalAirplane}");

Console.WriteLine($"Cloned airplane:{clonedAirplace}");