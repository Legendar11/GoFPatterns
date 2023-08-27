using AbstractFactory.Airplanes;
using AbstractFactory.Entities;
using AbstractFactory.ServiceTeams;

namespace AbstractFactory.LeasingFactories;

internal class MilitaryLeasingFactory : ILeasingFactory
{
    public Airplane CreateAirplane()
    {
        return new WarAirplane("FH-33", "EVEWS", new[] { "Missiles", "Machine gun" });
    }

    public ServiceTeam CreateServiceTeam()
    {
        return new MaintainceServiceTeam(new[] { "Conrad" }, DateTime.Parse("01.01.2030"));
    }
}
