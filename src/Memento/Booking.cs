namespace Memento;

internal class Booking : ISaver
{
    // State is private, we can only set it (via Memento)
    public BookingState State { private get; set; }

    public Booking(decimal price)
    {
        State = new BookingState
        {
            ExtraServices = new List<(string, decimal)>(),
            TotalPrice = price,
            OriginalPrice = price
        };
    }

    /// <summary>
    /// Add a new change to State: add extra ervice.
    /// </summary>
    public void AddExtraService(string name, decimal price)
    {
        float markupPercentage = 0.10f;

        State.ExtraServices.Add((name, price));

        // Client shouldn't see TotalPrice - we aply additional secret markup,
        // That's why State is private and encapsulation should be provided via Memento
        var priceWithMarkup = price + price * (decimal)markupPercentage;
        State.TotalPrice += priceWithMarkup;
    }

    /// <summary>
    /// Provide a new snapshot of current state.
    /// </summary>
    public IMemento Save() => new BookingMemento(this, new BookingState(State));

    public override string ToString()
    {
        return $"""
        Booking:
            {nameof(State.TotalPrice)}: {State.TotalPrice}
            {nameof(State.ExtraServices)}: {string.Join(", ", State.ExtraServices)}
            {nameof(State.OriginalPrice)}: {State.OriginalPrice}
        --------------------------------------------------------------
        """;
    }
}
