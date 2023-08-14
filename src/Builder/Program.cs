using Builder;
using Builder.Characters;

// Gand of Four, Builder:
// The intent of the Builder design pattern is to separate the construction
// of a complex object from its representation.
// By doing so, the same construction process can create different representations.

IGroupBuilder groupBuilder;

// one representation of builder, will create a group
groupBuilder = new AdventureGroupBuilder();
var adventureGroup = groupBuilder
    .SetDestination("New Jericho")
    .AddCharacter(new Priest())
    .AddCharacter(new Thief())
    .AddCharacter(new Bard())
    .AddLuckChance()
    .Build();

Console.WriteLine($"Adventure Group win chance is: {adventureGroup.WinChance:0.00}");
Console.WriteLine();

// second representation of builder, will create a group
// by different rules with different result
groupBuilder = new StandartGroupBuilder();
var standardGroup = groupBuilder
    .SetDestination("Hanaan")
    .AddCharacter(new Paladin())
    .Build();

Console.WriteLine($"Standard Group win chance is: {standardGroup.WinChance:0.00}");
Console.WriteLine();