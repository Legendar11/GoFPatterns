namespace Memento;

/// <summary>
/// Memento keeps info about provided snapshot.
/// </summary>
internal class BookingMemento : IMemento
{
    // Keep reference to original object (Originator)
    private readonly Booking _booking;
    private readonly BookingState _state;

    public BookingMemento(Booking booking, BookingState state)
    {
        _booking = booking;
        _state = state;
    }

    public void Restore()
    {
        _booking.State = _state;
    }
}
