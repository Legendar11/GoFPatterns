namespace Prototype;

internal class Kingdom : ICloneable
{
    private decimal _money;
    private decimal _debt;

    public int PeopleCount { get; set; }

    public List<KingdomDomain> Domains { get; init; }

    public Kingdom(decimal money, decimal debt, int peopleCount)
    {
        _money = money;
        _debt = debt;
        PeopleCount = peopleCount;
        Domains = new List<KingdomDomain>();
    }

    public object Clone() => DeepClone();

    // Shallow copy, set all values as is
    public Kingdom ShallowClone() =>
        // we can also use MemberwiseClone() here
        new(_money, _debt, PeopleCount)
        {
            Domains = Domains
        };

    // Deep copy, set all values as is
    // but provide coping for dependendable objects
    public Kingdom DeepClone() =>
        new(_money, _debt, PeopleCount)
        {
            Domains = Domains
                .Select(d => new KingdomDomain { Name = d.Name })
                .ToList()
        };

    public override string ToString()
    {
        return $"""
            Kingdom has:
                Money: {_money}
                Debt: {_debt}
                People: {PeopleCount}
                Domains: {string.Join("; ", Domains.Select(x => x.Name))}
        """;
    }
}
