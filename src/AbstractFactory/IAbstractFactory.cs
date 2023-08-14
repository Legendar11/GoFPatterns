namespace AbstractFactory;

/// <summary>
/// Abstract factory for weaponry creation.
/// </summary>
internal interface IAbstractFactory
{
    /// <summary>
    /// Each factory decides which objects will be instantiated.
    /// Different factories will create their own default sword.
    /// </summary>
    ISword CreateDefaultSword();

    /// <summary>
    /// Each factory decides which objects will be instantiated.
    /// Different factories will create their own default armour.
    /// </summary>
    IArmour CreateDefaultArmour();

    /// <summary>
    /// Each factory decides which objects will be instantiated.
    /// Different factories will create their own default transport.
    /// </summary>
    ITransport CreateDefaultTransport();
}
