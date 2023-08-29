using System.Collections;

namespace Iterator.Iterators;

internal class GroupByIdIterator : IEnumerator<UserLog>
{
    private readonly UserLog[] _users;
    private int _currentIndex;

    public GroupByIdIterator(UserLog[] users)
    {
        _users = users.OrderBy(u => u.UserId).ToArray();
        _currentIndex = -1;
    }

    public UserLog Current => _users[_currentIndex];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (_currentIndex < _users.Length - 1)
        {
            _currentIndex++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _currentIndex = 0;
    }
}