namespace Bridge.UserLogs;

/// <summary>
/// RegularUserLog will save all events as is with additional metadata (DateTime).
/// </summary>
internal class RegularUserLog : IUserLog
{
    private readonly List<(string Event, string Decscription, DateTime DateTime)> _events = new();

    public void Add(string eventType, string description)
    {
        _events.Add((eventType, description, DateTime.UtcNow));
    }

    public IEnumerable<string> GetLog()
    {
        return _events.Select(l => $"[{l.DateTime}] [{l.Event} {l.DateTime}]");
    }
}
