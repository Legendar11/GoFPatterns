namespace Observer.EventImplementation;

internal class User
{
    public event EventHandler<UserChangedEventArgs>? OnUserChanged;

    public User(string usernName, int age)
    {
        _userName = usernName;
        _age = age;
    }

    private string _userName;
    public string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            string previous = _userName;
            _userName = value;

            OnUserChanged?.Invoke(this, new UserChangedEventArgs
            {
                Field = nameof(UserName),
                OldValue = previous,
                NewValue = value
            });
        }
    }

    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            int previous = _age;
            _age = value;

            OnUserChanged?.Invoke(this, new UserChangedEventArgs
            {
                Field = nameof(Age),
                OldValue = previous,
                NewValue = value
            });
        }
    }
}
