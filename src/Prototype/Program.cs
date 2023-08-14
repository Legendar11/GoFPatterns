using Prototype;

// Gang of Four, Prototype:
// The prototype pattern is used to instantiate a new object
// by copying all of the properties of an existing object,
// creating an independent clone.
// This practise is particularly useful when
// the construction of a new object is inefficient.

var originalingdom = new Kingdom(money: 100, debt: 40, peopleCount: 200)
{
    Domains = new List<KingdomDomain> { new KingdomDomain { Name = "Icefall" } }
};

var newKingdom = (Kingdom)originalingdom.Clone();

newKingdom.PeopleCount = 300;
newKingdom.Domains.Add(new KingdomDomain { Name = "Magician Sunrise" });

Console.WriteLine($"Original kingdom:{Environment.NewLine}{originalingdom}{Environment.NewLine}");

Console.WriteLine($"New kingdom:{Environment.NewLine}{newKingdom}{Environment.NewLine}");