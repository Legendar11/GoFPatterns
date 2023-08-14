using AbstractFactory.Armours;
using AbstractFactory.Swords;
using AbstractFactory.Transports;

namespace AbstractFactory.Factories;

internal class VillageFactory : IAbstractFactory
{
    public IArmour CreateDefaultArmour() =>
        new LeatherArmour();

    public ISword CreateDefaultSword() =>
        new Miserakl();

    public ITransport CreateDefaultTransport() =>
        new Horse();
}
