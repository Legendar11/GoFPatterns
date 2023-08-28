using FactoryMethod.Enums;
using FactoryMethod.Swords;

namespace FactoryMethod;

/// <summary>
/// Airspeed company is able to create airplanes.
/// It implements requirements for <see cref="IAirplaneFactory"/>.
/// </summary>
internal class AirspeedAirplaneFactory : IAirplaneFactory
{
    public Airplane CreateCivilAirplane() => new Boeing();

    public Airplane CreateAirplane(Speed type, SeatCount metal) => (type, metal) switch
    {
        (Speed.Fast, SeatCount.Medium) => new Airbus(),
        (Speed.Average, SeatCount.Low) => new Potez(HasAdditionalSeats: true),
        (Speed.Fast, SeatCount.Large) => new Convair(),
        (Speed.Slow, SeatCount.Large) => new Boeing(),
        _ => throw new ArgumentOutOfRangeException($"Type: {type} with metal: {metal} is not supported")
    };
}
