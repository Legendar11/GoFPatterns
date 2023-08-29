using Mediator;
using Mediator.Users;

// Software design pattern Mediator:
// Defines an object that encapsulates a way to interact
// objects.The intermediary provides a weak connection of the system,
// objects explicitly reference each other by necessity and activate the theme
// any changes in the interaction between them can be independent.

ICorporativeChat chat = new CorporativeChat();

// Each participant of interaction gets a reference for mediator (ICorporativeChat)

IUser teamLeader = new TeamLeader(chat, "Roberto Benini");
chat.TeamLeader = teamLeader;

IUser designer = new Colleague(chat, "Wikky", "Designer");
chat.Colleagues.Add(designer);

IUser developer = new Colleague(chat, "Maxwell", "Developer");
chat.Colleagues.Add(developer);

designer.SendMessage("Hello, project is ready"); // mediator will perform their own logic between participants
Console.WriteLine("---------------------------------------");

teamLeader.SendMessage("Understood, we're ready to start");
Console.WriteLine("---------------------------------------");