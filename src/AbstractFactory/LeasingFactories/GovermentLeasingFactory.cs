using AbstractFactory.Airplanes;
using AbstractFactory.Entities;
using AbstractFactory.ServiceTeams;

namespace AbstractFactory.LeasingFactories;

internal class GovermentLeasingFactory : ILeasingFactory
{
    public Airplane CreateAirplane()
    {
        return new PassengerAirplane("TU-104", "JUTFFDF", false);
    }

    public ServiceTeam CreateServiceTeam()
    {
        return new RegularServiceTeam(new[] { "Ashely", "David", "Ricky" }, new[] { "Hammer", "Screwdriver" });
    }
}
