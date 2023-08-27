namespace Bridge;

internal abstract class User
{
    // Move logic regarding logs into seprate abstraction
    protected readonly IUserLog _userLog;

    // We set implementation of IUserLog via constructor,
    // we don't depend from only one implementation
    public User(IUserLog userLog)
    {
        _userLog = userLog;
    }

    // Successors will implement abstract methods

    public abstract void AddLogEntry(string eventType, string description);

    public abstract IEnumerable<string> GetLog();
}
