namespace Memento;

internal class BookingState
{
    public decimal TotalPrice { get; set; } = 0;

    public List<(string, decimal)> ExtraServices { get; set; } = new List<(string, decimal)>();

    public decimal OriginalPrice { get; set; } = 0;
}