namespace Adapter;

internal class TatooineService
{
    private int _population = 0;
    private int _exportedGoods = 0;
    private int _importedGoods = 0;

    public TatooineService(int population)
    {
        _population = population;
    }

    public void AddExported(int exportedGoods) => _exportedGoods += exportedGoods;

    public void AddImported(int importedGoods) => _importedGoods += importedGoods;

    // Tatooine can talk only by old and unstable protocol
    public object TrySendRequest(string request)
    {
        switch (request)
        {
            case "population":
                return _population;

            case "commerce_index":
                return (double)_exportedGoods / _importedGoods;
        }

        throw new NotSupportedException($"{nameof(TatooineService)} is not support request: {request}");
    }
}
