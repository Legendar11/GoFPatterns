using AbstractFactory.Entities;

namespace AbstractFactory.Airplanes;

internal record WarAirplane(
    string Name,
    string Registration,
    string[] Weaponry
) : Airplane(Name, Registration);
