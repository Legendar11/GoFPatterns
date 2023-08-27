namespace Bridge.Users;

internal class RegularUser : User
{
    public RegularUser(IUserLog userLog) : base(userLog)
    {
    }

    // Default behaviour with interaction IUserLog - 
    // delegate all work as is
    public override void AddLogEntry(string eventType, string description)
    {
        _userLog.Add(eventType, description);
    }

    public override IEnumerable<string> GetLog()
    {
        return _userLog.GetLog();
    }
}
