namespace Builder;

/// <summary>
/// Builder allows to create complex object by optional steps.
/// Pattern allows to encapsualte logic of creation from final result.
/// Different builders will create same object with different representation.
/// </summary>
internal interface IGroupBuilder
{
    IGroupBuilder AddCharacter(ICharacter character);

    IGroupBuilder SetDestination(string destination);

    IGroupBuilder AddLuckChance();

    Group Build();
}
