using FactoryMethod.Enums;

namespace FactoryMethod;

/// <summary>
/// Factory methods for airplanes creation.
/// </summary>
internal interface IAirplaneFactory
{
    /// <summary>
    /// Factory method decides which objects will be instantiated.
    /// Different factories methods will create their own default airplane.
    /// </summary>
    Airplane CreateCivilAirplane();

    /// <summary>
    /// Based on values passed to method factory method will create a concrete object.
    /// Factory method needs to specify which airplane will be created.
    /// </summary>
    Airplane CreateAirplane(Speed type, SeatCount metal);
}