namespace Mediator.Users;

internal class Colleague : IUser
{
    private readonly ICorporativeChat _chat;

    public string Name { get; init; }

    public string Position { get; init; }

    public Colleague(ICorporativeChat chat, string name, string position)
    {
        _chat = chat;
        Name = name;
        Position = position;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Position} {Name} received: {message}");
    }

    public void SendMessage(string message)
    {
        _chat.SendMessage(message, this);
    }
}
