namespace State;

internal class RepeatingState : State
{
    public override void NextState()
    {
        Console.WriteLine("-> From Repeating to Flashing");
        _flashLight.State = new FlashingState();
    }

    public override void PreviousState()
    {
        Console.WriteLine("<- From Repeating to Initial");
        _flashLight.State = new InitialState();
    }
}
