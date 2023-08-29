using NPOI.XWPF.UserModel;

namespace Visitor.Documents;

internal class DocxDocument : Document
{
    public DocxDocument(string path) : base(path)
    {
    }

    public XWPFDocument OriginalDocument => new(new MemoryStream(Content));

    public override Stream Render(Dictionary<string, object> placeholdersData)
    {
        XWPFDocument document = new(new MemoryStream(Content));

        ProcessDocument(document, placeholdersData);

        Stream memoryStream = new MemoryStream();
        document.Write(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    protected void ProcessDocument(XWPFDocument document, IDictionary<string, object> placeholdersData)
    {
        // inner stuff
        // ...
    }
}
