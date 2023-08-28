namespace Memento;

internal class Booking
{
    private BookingState _state;

    public Booking(decimal price)
    {
        _state = new BookingState
        {
            ExtraServices = new List<(string, decimal)>(),
            TotalPrice = price,
            OriginalPrice = price,
        };
    }

    public void AddExtraService(string name, decimal price)
    {
        float markupPercentage = 0.10f;

        _state.ExtraServices.Add((name, price));

        var priceWithMarkup = price + price * (decimal)markupPercentage;
        _state.TotalPrice += priceWithMarkup;
    }

    public IMemento<BookingState> Save() => new BookingMemento { State = _state };

    public void Restore(IMemento<BookingState> memento)
    {
        _state = memento.State;
    }
}
