using NPOI.XWPF.UserModel;

namespace Strategy.Processors;

internal class DocxDocument : IDocumentProcessor
{
    public Stream Process(Stream stream, Dictionary<string, object> placeholdersData)
    {
        XWPFDocument document = new (stream);

        ProcessDocument(document, placeholdersData);

        Stream memoryStream = new MemoryStream();
        document.Write(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }

    protected void ProcessDocument(XWPFDocument document, IDictionary<string, object> placeholdersData)
    {
        // inner stuff
        // ...
    }
}
