using AbstractFactory;
using AbstractFactory.Entities;
using AbstractFactory.LeasingFactories;

// Gang of Four, Abstract Factory:
// An interface for creating families of related or dependent objects
// without specifying their concrete classes.

ILeasingFactory factory;
Airplane airplane;
ServiceTeam serviceTeam;

factory = new GovermentLeasingFactory();
(airplane, serviceTeam) = (
    factory.CreateAirplane(),
    factory.CreateServiceTeam()
);
PrintInfo();

factory = new MilitaryLeasingFactory();
(airplane, serviceTeam) = (
    factory.CreateAirplane(),
    factory.CreateServiceTeam()
);
PrintInfo();

void PrintInfo() =>
    Console.WriteLine($"""
        {factory.GetType().Name}:
            {airplane.GetType().Name},
            {serviceTeam.GetType().Name}
        {Environment.NewLine}
    """);