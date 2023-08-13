using FactoryMethod.Enums;
using FactoryMethod.Swords;

namespace FactoryMethod;

/// <summary>
/// Royal blacksmith is able to create a swords.
/// It implements requirements for <see cref="ISwordFactory"/>.
/// </summary>
internal class RoyalBlacksmithFactory : ISwordFactory
{
    public ISword CreateDefaultSword() => new Gladius();

    public ISword CreateHandworkSword(SwordType type, MetalType metal) => (type, metal) switch
    {
        (SwordType.Longsword, MetalType.Metal) => new Flamberg(),
        (SwordType.Sabel, MetalType.Metal) => new Sigil(isEnchanted: true),
        (SwordType.Dagger, MetalType.Bronze) => new Miserakl(),
        (SwordType.Bastard, MetalType.Bronze) => new Gladius(),
        _ => throw new ArgumentOutOfRangeException($"Type: {type} with metal: {metal} is not supported")
    };
}
