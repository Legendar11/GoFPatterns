namespace Memento;

internal class BookingMemento : IMemento<BookingState>
{
    public BookingState State { get; set; } = null!;
}
