using AbstractFactory.Armours;
using AbstractFactory.Swords;
using AbstractFactory.Transports;

namespace AbstractFactory.Factories;

internal class RoyalFactory : IAbstractFactory
{
    public IArmour CreateDefaultArmour() =>
        new PlateArmour();

    public ISword CreateDefaultSword() =>
        new Gladius();

    public ITransport CreateDefaultTransport() =>
        new Chariot();
}