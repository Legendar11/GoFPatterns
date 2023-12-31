﻿using FactoryMethod;
using FactoryMethod.Enums;

// Gang of Four, Factory Method:
// Define an interface for creating an object, but let subclasses decide which class to instantiate.
// The Factory method lets a class defer instantiation it uses to subclasses.

IAirplaneFactory airplaneFactory = new AirspeedAirplaneFactory();

Airplane civilAirplane = airplaneFactory.CreateCivilAirplane();
Console.WriteLine($"Civil default airplane by Airspeed company: {civilAirplane.GetType().Name}");
Console.WriteLine();

Airplane customAirplane = airplaneFactory.CreateAirplane(Speed.Fast, SeatCount.Medium);
Console.WriteLine($"Custom airplane by Airspeed company: {customAirplane.GetType().Name}");
Console.WriteLine();