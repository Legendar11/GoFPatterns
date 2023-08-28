namespace Strategy;

internal interface IDocumentManager
{
    public IDocumentProcessor Processor { set; }

    void ProcessDocument(string pathIn, string pathOut, Dictionary<string, object> placeholdersData);
}
