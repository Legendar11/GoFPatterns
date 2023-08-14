using AbstractFactory.Armours;
using AbstractFactory.Swords;
using AbstractFactory.Transports;

namespace AbstractFactory.Factories;

internal class ForeignFactory : IAbstractFactory
{
    public IArmour CreateDefaultArmour() =>
        new ChainArmour();

    public ISword CreateDefaultSword() =>
        new Flamberg();

    public ITransport CreateDefaultTransport() =>
        new Horse();
}