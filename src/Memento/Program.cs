using Memento;

// Software design pattern Memento:
// Without violating encapsulation, fixes and takes it out of the object
// internal state so that you can later restore it to it an object.
// Allows to save incremental changes via additional class Caretaker. 

// Create original object
Booking booking = new Booking(100);

// We can't get Booking.State - it's private info,
// and Memento successfully provides this encapsulation.
//var state = booking.State; // produces error

// Caretaker for incremental changes in booking
ICaretaker caretaker = new Caretaker();

// Save current state
caretaker.AddMemento(booking.Save());

// Provide a new change
booking.AddExtraService("seat_selection", 20);

// Save changed state
caretaker.AddMemento(booking.Save());

// Ensure original object is changed
Console.WriteLine(booking);

// Add a new change
booking.AddExtraService("additional_meal", 70);

// Ensure original object is changed one more time
Console.WriteLine(booking);

// Revoke last change
caretaker.PopMemento().Restore();

// Ensure original object doesn't have last change
Console.WriteLine(booking);