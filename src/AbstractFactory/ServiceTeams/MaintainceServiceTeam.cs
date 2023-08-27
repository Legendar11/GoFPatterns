using AbstractFactory.Entities;

namespace AbstractFactory.ServiceTeams;

internal record MaintainceServiceTeam(
    string[] CrewNames,
    DateTime EndOfMaintaince
) : ServiceTeam(CrewNames);