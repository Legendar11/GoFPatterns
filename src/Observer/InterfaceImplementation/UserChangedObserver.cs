namespace Observer.InterfaceImplementation;

internal class UserChangedObserver : IObserver
{
    private readonly IState<UserState> _stateFetcher;
    private UserState _previosState;

    public UserChangedObserver(IState<UserState> stateFetcher)
    {
        _stateFetcher = stateFetcher;
        _previosState = new UserState(stateFetcher.State);
    }

    public void Update()
    {
        // fetch necessary data by state getter
        var changedState = _stateFetcher.State;

        // implemented logic
        if (_previosState.UserName != changedState.UserName)
        {
            Console.WriteLine($"User property '{nameof(UserState.UserName)}' changed from: '{_previosState.UserName}' to: '{changedState.UserName}'");
        }
        if (_previosState.Age != changedState.Age)
        {
            Console.WriteLine($"User property '{nameof(UserState.Age)}' changed from: '{_previosState.Age}' to: '{changedState.Age}'");
        }
        
        // save previous state
        _previosState = new UserState(changedState);
    }
}
