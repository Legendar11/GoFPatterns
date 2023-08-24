namespace Adapter;

internal class LogClient : ILogClient
{
    private static readonly Random _rand = new Random();

    private static string[] _eventTypes = new[]
    {
        "login",
        "reset_password",
        "change_restore_question"
    };

    public object GetLogForUser(string userId)
    {
        var recordsCount = _rand.Next(50, 100);

        var result = new object[recordsCount];
        foreach (var recordIterator in Enumerable.Range(0, recordsCount))
        {
            var eventType = _eventTypes[_rand.Next(0, _eventTypes.Length)];
            result[recordIterator] = new { Event = eventType, Description = GenerateDescription(), Date = RandomDate() };
        }
        return result;
    }

    private static string GenerateDescription()
    {
        var descriptions = new[]
        {
            "test",
            "debug",
            "no_info"
        };
        return descriptions[_rand.Next(0, descriptions.Length)];
    }

    private static DateTime RandomDate()
    {
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(_rand.Next(range));
    }
}
