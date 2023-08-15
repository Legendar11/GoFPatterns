namespace FactoryMethod.Swords;

internal class Potez : IAirplane
{
    public bool HasAdditionalSeats { get; set; }

    public Potez(bool hasAdditionalSeats)
    {
        HasAdditionalSeats = hasAdditionalSeats;
    }
}
