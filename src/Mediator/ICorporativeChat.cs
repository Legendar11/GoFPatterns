namespace Mediator;

/// <summary>
/// Mediator interface - it's handle communication between Colleagues and TeamLeader.
/// </summary>
internal interface ICorporativeChat
{
    public IUser? TeamLeader { get; set; }

    public List<IUser> Colleagues { get; set; }

    void SendMessage(string message, IUser user);
}
