namespace Bridge;

internal interface IUserLog
{
    void Add(string eventType, string description);

    IEnumerable<string> GetLog();
}
