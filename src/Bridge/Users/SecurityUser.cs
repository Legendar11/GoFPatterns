namespace Bridge.Users;

internal class SecurityUser : User
{
    public SecurityUser(IUserLog userLog) : base(userLog)
    {
    }

    // We specify User abstraction by adding
    // new preconditions for work with with IUserLog,
    // but we still delegate all necessary work to inner implementation
    public override void AddLogEntry(string eventType, string description)
    {
        if (!IsAccessAllowed())
        {
            return;
        }

        // Delegate work as is
        _userLog.Add(eventType, description);
    }

    public override IEnumerable<string> GetLog()
    {
        if (!IsAccessAllowed())
        {
            return Enumerable.Empty<string>();
        }

        // Delegate work as is
        return _userLog.GetLog();
    }

    // Mock method for demonstration
    private bool IsAccessAllowed() => true;
}
