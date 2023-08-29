namespace Mediator;

internal class CorporativeChat : ICorporativeChat
{
    public IUser? TeamLeader { get; set; }

    public List<IUser> Colleagues { get; set; } = new List<IUser>();

    /// <summary>
    /// Perform interaction between objects.
    /// </summary>
    public void SendMessage(string message, IUser user)
    {
        foreach (var innerUser in Colleagues)
        {
            if (innerUser == user)
            {
                continue; 
            }
            innerUser.ReceiveMessage(message);
        }

        TeamLeader?.ReceiveMessage(message);
    }
}
