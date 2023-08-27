namespace Bridge.UserLogs;

/// <summary>
/// UniqueUserLog will save oly unique events without any additional information.
/// </summary>
internal class UniqueUserLog : IUserLog
{
    private readonly Dictionary<string, string> _events = new Dictionary<string, string>();

    public void Add(string eventType, string description)
    {
        if (_events.ContainsKey(eventType))
        {
            _events[eventType] = description;
        }
        else
        {
            _events.Add(eventType, description);
        }
    }

    public IEnumerable<string> GetLog()
    {
        return _events.Select(kv => $"{kv.Key}:{kv.Value}");
    }
}
