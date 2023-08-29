using System.Collections;

namespace Iterator.Iterators;

internal class InfiniteLoopIterator : IEnumerator<UserLog>
{
    private readonly UserLog[] _users;
    private int _currentIndex;

    public InfiniteLoopIterator(UserLog[] users)
    {
        _users = users;
        _currentIndex = 0;
    }

    public UserLog Current => _users[_currentIndex];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _currentIndex = (_currentIndex + 1) % _users.Length;
        return true;
    }

    public void Reset()
    {
        throw new NotSupportedException("Loop is infinite");
    }
}