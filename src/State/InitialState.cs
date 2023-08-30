namespace State;

internal class InitialState : State
{
    public override void NextState()
    {
        Console.WriteLine("-> From Initial to Repeating");
        _flashLight.State = new RepeatingState();
    }

    public override void PreviousState()
    {
        Console.WriteLine("<- From Initial to Flashing");
        _flashLight.State = new FlashingState();
    }
}
