using AbstractFactory;
using AbstractFactory.Factories;

// Gang of Four, Abstract Factory:
// An interface for creating families of related or dependent objects
// without specifying their concrete classes.

IAbstractFactory factory;
IArmour armour;
ISword sword;
ITransport transport;

factory = new VillageFactory();
(armour, sword, transport) = (
    factory.CreateDefaultArmour(),
    factory.CreateDefaultSword(),
    factory.CreateDefaultTransport()
);
PrintInfo();

factory = new RoyalFactory();
(armour, sword, transport) = (
    factory.CreateDefaultArmour(),
    factory.CreateDefaultSword(),
    factory.CreateDefaultTransport()
);
PrintInfo();

factory = new ForeignFactory();
(armour, sword, transport) = (
    factory.CreateDefaultArmour(),
    factory.CreateDefaultSword(),
    factory.CreateDefaultTransport()
);
PrintInfo();

void PrintInfo() =>
    Console.WriteLine($"""
        {factory.GetType().Name}:
            {armour.GetType().Name},
            {sword.GetType().Name},
            {transport.GetType().Name}
        {Environment.NewLine}
    """);