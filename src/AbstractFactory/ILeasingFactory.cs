using AbstractFactory.Entities;

namespace AbstractFactory;

/// <summary>
/// Abstract factory.
/// </summary>
internal interface ILeasingFactory
{
    /// <summary>
    /// Each factory decides which objects will be instantiated.
    /// Different factories will create their own airplane.
    /// </summary>
    Airplane CreateAirplane();

    /// <summary>
    /// Each factory decides which objects will be instantiated.
    /// Different factories will create their own service team.
    /// </summary>
    ServiceTeam CreateServiceTeam();
}
