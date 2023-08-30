namespace State;
internal class FlashingState : State
{
    public override void NextState()
    {
        Console.WriteLine("-> From Flashing to Initial");
        _flashLight.State = new InitialState();
    }

    public override void PreviousState()
    {
        Console.WriteLine("<- From Flashing to Repeating");
        _flashLight.State = new RepeatingState();
    }
}
