using Iterator.Iterators;
using System.Collections;

namespace Iterator;

internal class UsersLogs : IEnumerable<UserLog>
{
    private readonly List<UserLog> _usersLogs;

    public IEnumerator<UserLog> Iterator { get; set; }

    public UserLog[] Users => _usersLogs.ToArray();

    public UsersLogs(IEnumerable<UserLog> userLogs)
    {
        _usersLogs = userLogs.ToList();
        Iterator = _usersLogs.GetEnumerator();
    }

    public IEnumerator<UserLog> GetEnumerator() => Iterator;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
