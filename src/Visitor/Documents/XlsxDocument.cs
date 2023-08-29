using NPOI.XSSF.UserModel;

namespace Visitor.Documents;

internal class XlsxDocument : Document
{
    public XlsxDocument(string path) : base(path)
    {
    }

    public XSSFWorkbook OriginalDocument => new(new MemoryStream(Content));

    public override Stream Render(Dictionary<string, object> placeholdersData)
    {
        XSSFWorkbook document = new(new MemoryStream(Content));

        ProcessDocument(document, placeholdersData);

        Stream memoryStream = new MemoryStream();
        document.Write(memoryStream, true);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    protected void ProcessDocument(XSSFWorkbook document, IDictionary<string, object> parameters)
    {
        // inner stuff
        // ...
    }
}
