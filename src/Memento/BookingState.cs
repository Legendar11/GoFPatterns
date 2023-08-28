namespace Memento;

internal class BookingState
{
    public decimal TotalPrice { get; set; } = 0;

    public List<(string, decimal)> ExtraServices { get; set; } = new List<(string, decimal)>();

    public decimal OriginalPrice { get; set; } = 0;

    public BookingState()
    {
    }

    public BookingState(BookingState original)
    {
        OriginalPrice = original.OriginalPrice;
        TotalPrice = original.TotalPrice;
        ExtraServices = new List<(string, decimal)>(original.ExtraServices);
    }
}