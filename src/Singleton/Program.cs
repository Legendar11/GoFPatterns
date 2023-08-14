using Singleton;

// Gang of Four, Singleton:
// It restricts a class to have only one instance
// and provides a global point of access to that instance.
// The singleton class is responsible for creating its own instance,
// and making sure that only one instance is created.

//// creation date will be set immediately
//var eagerInstance = World.GetInstance();
//Console.WriteLine(eagerInstance.CreationDate);

//Thread.Sleep(5000);

//// creation date will be created only after request the lazy instance
//var lazyInstance = World.GetLazyInstance();
//Console.WriteLine(lazyInstance.CreationDate);



// we requested a static property, so 
// eagerInstance.CreationDate will be set as well
var lazyInstance = World.GetLazyInstance();
Console.WriteLine(lazyInstance.CreationDate);

Thread.Sleep(5000);

var eagerInstance = World.GetInstance();
Console.WriteLine(eagerInstance.CreationDate);