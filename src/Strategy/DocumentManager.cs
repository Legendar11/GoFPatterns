namespace Strategy;

internal class DocumentManager : IDocumentManager
{
    public IDocumentProcessor Processor { private get; set; }

    public DocumentManager(IDocumentProcessor processor)
    { 
        Processor = processor; 
    }

    public void ProcessDocument(string pathIn, string pathOut, Dictionary<string, object> placeholdersData)
    {
        Stream outputStream;
        
        using (FileStream fileStreamIn = new FileStream(pathIn, FileMode.Open))
        {
            Console.WriteLine($"Perform operator by: {Processor.GetType().Name}");
            outputStream = Processor.Process(fileStreamIn, placeholdersData);
        }

        using (FileStream fileStreamOut = new FileStream(pathOut, FileMode.Create))
        {
            outputStream.CopyTo(fileStreamOut);
        }
    }
}
