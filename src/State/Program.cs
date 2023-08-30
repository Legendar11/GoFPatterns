// See https://aka.ms/new-console-template for more information
using State;

// Software design pattern State:
// Allows an object to change its behavior depending on the internal states.
// From the outside, it seems that the class of the object has changed.


FlashLight flashLight = new FlashLight(new InitialState());

flashLight.NextState(); // change internal states
flashLight.NextState();
flashLight.PreviousState();
flashLight.PreviousState();