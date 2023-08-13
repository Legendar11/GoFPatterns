using FactoryMethod.Enums;

namespace FactoryMethod;

/// <summary>
/// Factory methods for swords creation.
/// </summary>
internal interface ISwordFactory
{
    /// <summary>
    /// Factory method decides which objects will be instantiated.
    /// Different factories methods will create their own default sword.
    /// </summary>
    ISword CreateDefaultSword();

    /// <summary>
    /// Based on values passed to method factory method will create a concrete object.
    /// Factory method needs to specify which sword will be created.
    /// </summary>
    ISword CreateHandworkSword(SwordType type, MetalType metal);
}