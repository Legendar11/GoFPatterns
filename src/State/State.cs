namespace State;

internal abstract class State
{
    protected FlashLight _flashLight = null!;
    public FlashLight FlashLight { set => _flashLight = value; }

    public abstract void NextState();

    public abstract void PreviousState();
}
