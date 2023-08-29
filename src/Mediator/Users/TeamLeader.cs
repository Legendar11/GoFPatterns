using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Users;

internal class TeamLeader : IUser
{
    private readonly ICorporativeChat _chat;

    public string Name { get; init; }

    public TeamLeader(ICorporativeChat chat, string name)
    {
        _chat = chat;
        Name = name;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"Team leader {Name} received: {message}");
    }

    public void SendMessage(string message)
    {
        _chat.SendMessage(message, this);
    }
}
