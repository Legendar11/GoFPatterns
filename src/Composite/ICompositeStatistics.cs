namespace Composite;

/// <summary>
/// Composite interface for group of <see cref="IStatistics"/>
/// </summary>
internal interface ICompositeStatistics : IStatistics
{
    /// <summary>
    /// Group of child elements.
    /// </summary>
    List<IStatistics> InnerStatistics { get; }
}
