namespace Observer.InterfaceImplementation;

internal class User : IState<UserState>, IObservable
{
    private readonly List<IObserver> _observers = new ();

    public UserState State { get; private set; }

    public User(string usernName, int age)
    {
        State = new UserState(usernName, age);
    }

    public void AttachObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void ChangeUserName(string userName)
    {
        State.UserName = userName;
        Notify();
    }

    public void ChangeAge(int age)
    {
        State.Age = age;
        Notify();
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}
