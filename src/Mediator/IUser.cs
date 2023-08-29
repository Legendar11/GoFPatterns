namespace Mediator;

internal interface IUser
{
    string Name { get; init; }

    /// <summary>
    /// Send a notification for mediator.
    /// </summary>
    void SendMessage(string message);

    /// <summary>
    /// Get information from notification from mediator.
    /// </summary>
    /// <param name="message"></param>
    void ReceiveMessage(string message);
}
