namespace Prototype;

internal class Passenger : ICloneable
{
    public string Name { get; set; } = null!;

    public object Clone()
    {
        return MemberwiseClone();
    }
}
