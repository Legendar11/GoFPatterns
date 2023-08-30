namespace State;

internal class FlashLight
{
    private State _state;

    public State State
    {
        set
        {
            _state = value;
            _state.FlashLight = this;
        }
    }

    public FlashLight(State state)
    {
        State = state;
    }

    public void NextState()
    {
        _state.NextState();
    }

    public void PreviousState()
    {
        _state.PreviousState();
    }
}
