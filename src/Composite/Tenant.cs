namespace Composite;

/// <summary>
/// Tenant is composite element - it has childs of statistics.
/// For implement <see cref="IStatistics.GetLastDateOfLogin"/>
/// it needs to iterate through childs.
/// </summary>
internal class Tenant : ICompositeStatistics
{
    public List<IStatistics> InnerStatistics { get; init; } = new List<IStatistics>();

    /// <summary>
    /// Get last date of login from childs.
    /// </summary>
    public DateTime GetLastDateOfLogin()
    {
        if (InnerStatistics.Count == 0)
        {
            throw new NotSupportedException("Cannot perform calculate: list of childs is empty");
        }

        return InnerStatistics
            .Select(s => s.GetLastDateOfLogin())
            .OrderByDescending(d => d)
            .First();
    }
}
