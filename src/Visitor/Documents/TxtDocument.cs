using System.Text;

namespace Visitor.Documents;

internal class TxtDocument : Document
{
    public TxtDocument(string path) : base(path)
    {
    }

    public override Stream Render(Dictionary<string, object> placeholdersData)
    {
        byte[] data = Content.ToArray();
        string content = Encoding.UTF8.GetString(data);

        StringBuilder builder = new StringBuilder(content);
        foreach (var (key, value) in placeholdersData)
        {
            builder = builder.Replace("{" + key + "}", value.ToString());
        }

        var memoryStream = new MemoryStream();
        memoryStream.Position = 0;
        var sreamWriter = new StreamWriter(memoryStream);
        sreamWriter.Write(builder.ToString());
        sreamWriter.Flush();
        memoryStream.Position = 0;

        return memoryStream;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
