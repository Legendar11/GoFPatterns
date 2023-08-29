namespace Observer.EventImplementation;

internal class UserChangedEventArgs : EventArgs
{
    public string Field { get; set; } = null!;

    public object? OldValue { get; set; }

    public object? NewValue { get; set; }
}
