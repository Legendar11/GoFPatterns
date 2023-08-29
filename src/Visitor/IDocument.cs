namespace Visitor;

internal interface IDocument
{
    /// <summary>
    /// Default method for some operation.
    /// </summary>
    Stream Render(Dictionary<string, object> placeholdersData);

    /// <summary>
    /// Accept a visitor which performs some other operator.
    /// </summary>
    void Accept(IVisitor visitor);
}
