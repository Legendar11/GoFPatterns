namespace Builder;

internal class AdventureGroupBuilder : IGroupBuilder
{
    private readonly List<ICharacter> _characters;
    private string? _destination;
    private double? _luckChance;

    public AdventureGroupBuilder()
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
        _destination = destination;
        return this;
    }

    public IGroupBuilder AddLuckChance()
    {
        _luckChance = new Random().NextDouble();
        return this;
    }

    public Group Build()
    {
        var winChance = 0.0;

        winChance += _characters.Count % 9 / 10;

        winChance += _luckChance ?? 0.0;

        if (winChance > 0.5
            && _destination is not null
            && _destination.Length > 5)
        {
            winChance -= 0.2;
        }

        return new Group
        {
            Characters = _characters.ToArray(),
            WinChance = winChance
        };
    }
}
