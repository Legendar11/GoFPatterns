using Flyweight;

// Software design pattern Flyweight:
// The flyweight software design pattern refers to an object that minimizes memory usage
// by sharing some of its data with other similar objects.
// Flyweight objects can:
// 1. store intrinsic state that is invariant, context-independent and shareable,
// 2. provide an interface for passing in extrinsic state that is variant, context-dependent and can't be shared.

// Factory caches most common intrinsic states
IAirplaneFlyweightFactory factory = new AirplaneFlyweightFactory(new[]
{
    new AirplaneShared("Cukurs", "Latvia"),
    new AirplaneShared("Bristol", "United Kingdom"),
    new AirplaneShared("Hawker", "United Kingdom"),
    new AirplaneShared("Embraer", "Brazil"),
    new AirplaneShared("Commonwealth Aircraft", "Australia")
});

// We get object from factory and perform the operaton.
// Here is no difference between regular object and flyweight object - 
// So flyweight is acting as regular.

factory
    .GetAirplaneFlyweight(new AirplaneShared("Embraer", "Brazil")) // request cached shared (intrinsic) state
    .DisplayFullInfo(new AirplaneUnique("Red", new[] { "Joe", "Mary" })); // perform operation by unique (extrinsic) state

factory
    .GetAirplaneFlyweight(new AirplaneShared("Avro", "Canada")) // request new shared (intrinsic) state and cache it
    .DisplayFullInfo(new AirplaneUnique("Blue", new[] { "Jacob", "Railey" })); // perform operation by unique (extrinsic) state

factory
    .GetAirplaneFlyweight(new AirplaneShared("Avro", "Canada")) // request already cached shared (intrinsic) state
    .DisplayFullInfo(new AirplaneUnique("Red", new[] { "Olivia", "Jessica" })); // perform operation by unique (extrinsic) state