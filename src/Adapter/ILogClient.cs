namespace Adapter;

/// <summary>
/// Interface returns correct but incompatible data.
/// </summary>
internal interface ILogClient
{
    object GetLogForUser(string userId);
}
