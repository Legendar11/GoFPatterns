using System.Text;

namespace Strategy.Processors;

internal class TextProcessor : IDocumentProcessor
{
    public Stream Process(Stream stream, Dictionary<string, object> placeholdersData)
    {
        MemoryStream memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);

        byte[] data = memoryStream.ToArray();
        string content = Encoding.UTF8.GetString(data);

        StringBuilder builder = new StringBuilder(content);
        foreach (var (key, value) in placeholdersData)
        {
            builder = builder.Replace("{" + key + "}", value.ToString());
        }

        memoryStream.Flush();
        memoryStream.Position = 0;
        var sreamWriter = new StreamWriter(memoryStream);
        sreamWriter.Write(builder.ToString());
        sreamWriter.Flush();
        memoryStream.Position = 0;

        return memoryStream;
    }
}
