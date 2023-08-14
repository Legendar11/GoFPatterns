namespace Builder;

internal class StandartGroupBuilder : IGroupBuilder
{
    private readonly List<ICharacter> _characters;
    private string? _destination;
    private double? _luckChance;

    public StandartGroupBuilder()
    {
        _characters = new List<ICharacter>();
        _destination = null;
        _luckChance = null;
    }

    public IGroupBuilder AddCharacter(ICharacter character)
    {
        _characters.Add(character);
        return this;
    }

    public IGroupBuilder SetDestination(string destination)
    {
        const string allowedDestination = "Hanaan";

        if (destination != allowedDestination)
        {
            throw new ArgumentException($"Only {allowedDestination} is allowed");
        }

        _destination = destination;
        return this;
    }

    public IGroupBuilder AddLuckChance()
    {
        _luckChance = 0.3;
        return this;
    }

    public Group Build()
    {
        var winChance = 0.5;

        winChance += _luckChance ?? 0;

        return new Group
        {
            Characters = _characters.ToArray(),
            WinChance = winChance
        };
    }
}
