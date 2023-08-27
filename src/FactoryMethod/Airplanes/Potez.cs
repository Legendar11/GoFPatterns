namespace FactoryMethod.Swords;

internal record Potez : Airplane
{
    public bool HasAdditionalSeats { get; set; }

    public Potez(bool hasAdditionalSeats)
    {
        HasAdditionalSeats = hasAdditionalSeats;
    }
}
