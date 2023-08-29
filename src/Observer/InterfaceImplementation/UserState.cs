namespace Observer.InterfaceImplementation;

internal sealed class UserState
{
    public string UserName { get; set; } = null!;

    public int Age { get; set; }

    public UserState(string userName, int age)
    {
        UserName = userName;
        Age = age;
    }

    public UserState(UserState other)
    {
        UserName = other.UserName;
        Age = other.Age;
    }
}
