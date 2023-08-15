using Builder;

// Gand of Four, Builder:
// The intent of the Builder design pattern is to separate the construction
// of a complex object from its representation.
// By doing so, the same construction process can create different representations.

// Using builder - we can create object in a fluent way with optional steps.
// Each builder has own logic how to implement each step of construction
// and how to provide builded final result.
IPassengerInfoBuilder builder;

// One implementation of builder
builder = new AirSerbiaPassengerInfoBuilder();
var airSerbiaPassengerInfo = builder
    .SetPassengerFullName("Zoltan_Kines_Allaby_Vicconging") // will parse full name
    .AddMeal("Standard meal")
    .AddMeal("Standard meal")
    .AddMeal("VIP meal") // will save all added meals
    .RequestWheelChair()
    .SetSeat("1B")
    .Build();
Console.WriteLine($"Passenger information by Air Serbia:{airSerbiaPassengerInfo}");

// Second implementation of builder
builder = new MontenegroAirlinesPassengerInfoBuilder();
var montenegroAirlinesPassengerInfo = builder
    .SetPassengerFullName("Zoltan_Kines_Allaby_Vicconging") // will parse only first and second name
    .AddMeal("Standard meal")
    .AddMeal("VIP meal") // will overwrite previous meal
    .Build();
Console.WriteLine($"Passenger information by Montenegro Airlines:{montenegroAirlinesPassengerInfo}");

