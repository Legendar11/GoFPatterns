using AbstractFactory.Entities;

namespace AbstractFactory.Airplanes;

internal record PassengerAirplane(
    string Name,
    string Registration,
    bool IsInternationalAllowed
) : Airplane(Name, Registration);
