using Observer.InterfaceImplementation;

// Software design pattern Observer:
// Defines a one-to-many dependency between objects such as
// in such a way that when the state of one object changes,
// all dependent on it is notified of this and automatically updated.

// Observer has push-based model and pull-based model.
// Push-based - notify all observers and pass all necessary information in method 'Notify' parameters.
// Pull-based - notify all observers and provide all necessary information by their request with special method 'GetState'.

// Push-based implementation:

Observer.EventImplementation.User userByEvents = new ("John Francis Bongiovi", 61);
userByEvents.OnUserChanged += (s, e) => Console.WriteLine($"User property '{e.Field}' changed from: '{e.OldValue}' to: '{e.NewValue}'");
userByEvents.UserName = "Jonny";
userByEvents.Age = 30;

Console.WriteLine("-------------------------------");

// Pull-based implementation:
Observer.InterfaceImplementation.User userByInterfaces = new("Taika Vaititi", 36);
userByInterfaces.AttachObserver(new UserChangedObserver(userByInterfaces));
userByInterfaces.ChangeUserName("Tikki");
userByInterfaces.ChangeAge(45);