using FactoryMethod;
using FactoryMethod.Enums;

// Gang of Four, Factory Method:
// Define an interface for creating an object, but let subclasses decide which class to instantiate.
// The Factory method lets a class defer instantiation it uses to subclasses.

ISwordFactory swordFactory = new RoyalBlacksmithFactory();

ISword swordRequestedByGoverment = swordFactory.CreateDefaultSword();
Console.WriteLine($"Goverment requested: {swordRequestedByGoverment.GetDescription()}");
Console.WriteLine();

ISword swordRequestedByZoltan = swordFactory.CreateHandworkSword(SwordType.Sabel, MetalType.Metal);
Console.WriteLine($"Zoltan requested: {swordRequestedByZoltan.GetDescription()}");
Console.WriteLine();