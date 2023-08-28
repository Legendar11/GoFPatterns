namespace Memento;

internal class Booking
{
    private decimal _totalPrice = 0;

    public List<(string, decimal)> ExtraServices { get; private set; } = new List<(string, decimal)>();

    public decimal OriginalPrice { get; private set; } = 0;

    public Booking(decimal price)
    {
        OriginalPrice = price;
        _totalPrice = price;
    }

    public void AddExtraService(string name, decimal price)
    {
        float markupPercentage = 0.10f;

        ExtraServices.Add((name, price));

        var priceWithMarkup = price + price * (decimal)markupPercentage;
        _totalPrice += priceWithMarkup;
    }

    public IMemento Save() => new BookingMemento(_totalPrice, ExtraServices, OriginalPrice);

    public void Restore(IMemento memento)
    {
        var bookingMemento = (BookingMemento)memento;
        
        _totalPrice = bookingMemento.TotalPrice;
        ExtraServices = bookingMemento.ExtraServices;
        OriginalPrice = bookingMemento.OriginalPrice;
    }

    private record BookingMemento(
        decimal TotalPrice,
        List<(string, decimal)> ExtraServices,
        decimal OriginalPrice
    ) : IMemento;
}
