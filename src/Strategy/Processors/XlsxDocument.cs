using NPOI.XSSF.UserModel;

namespace Strategy.Processors;

internal class XlsxDocument : IDocumentProcessor
{
    public Stream Process(Stream stream, Dictionary<string, object> placeholdersData)
    {
        XSSFWorkbook document = new (stream);

        ProcessDocument(document, placeholdersData);

        Stream memoryStream = new MemoryStream();
        document.Write(memoryStream, true);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }

    protected void ProcessDocument(XSSFWorkbook document, IDictionary<string, object> parameters)
    {
        // inner stuff
        // ...
    }
}