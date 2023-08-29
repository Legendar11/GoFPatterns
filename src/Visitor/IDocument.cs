namespace Visitor;

internal interface IDocument
{
    Stream Render(Dictionary<string, object> placeholdersData);

    void Accept(IVisitor visitor);
}
