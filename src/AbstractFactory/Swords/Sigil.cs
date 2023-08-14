namespace AbstractFactory.Swords;

internal class Sigil : ISword
{
    public bool IsEnchanted { get; set; }

    public Sigil(bool isEnchanted)
    {
        IsEnchanted = isEnchanted;
    }

    public string GetDescription() =>
        "Sword with potentially unlimited power with mysterious origin";
}
