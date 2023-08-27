using AbstractFactory.Entities;

namespace AbstractFactory.ServiceTeams;

internal record RegularServiceTeam(
    string[] CrewNames,
    string[] Tools
) : ServiceTeam(CrewNames);