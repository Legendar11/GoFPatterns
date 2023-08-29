using System.IO;

namespace Visitor.Documents;

internal abstract class Document : IDocument
{
    public string Name { get; init; } = null!;

    public byte[] Content { get; init; } = null!;

    public Document(string path)
    {
        Name = path;
        
        using FileStream fileStreamIn = new FileStream(path, FileMode.Open);
        using MemoryStream memoryStream = new MemoryStream();
        fileStreamIn.CopyTo(memoryStream);
        Content = memoryStream.ToArray();
    }

    public abstract void Accept(IVisitor visitor);

    public abstract Stream Render(Dictionary<string, object> placeholdersData);
}
