namespace Strategy;

internal interface IDocumentProcessor
{
    /// <summary>
    /// Different strategies will execute their own version of algorithm.
    /// </summary>
    Stream Process(Stream stream, Dictionary<string, object> placeholdersData);
}
