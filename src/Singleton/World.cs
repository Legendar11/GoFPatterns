namespace Singleton;

internal class World
{
    // Will be initiated only by demand
    private static readonly Lazy<World> _lazyInstance = new(() => new World());

    // Will be initiated after first call to any static property and before static constructor
    private static readonly World _instance = new();

    public DateTime CreationDate { get; } = DateTime.Now;

    private World()
    {
    }

    public static World GetLazyInstance()
    {
        return _lazyInstance.Value;
    }

    public static World GetInstance()
    {
        return _instance;
    }
}
