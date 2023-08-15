namespace Adapter;

/// <summary>
/// Adapter allows to communicate with Tatooine
/// in a stable, comfortable and safety way
/// </summary>
internal class TatooineServiceAdapter
{
    private readonly TatooineService _service;

    public TatooineServiceAdapter(TatooineService service)
    {
        _service = service;
    }

    // Adapter encapsulate all problems regarding how exactly to talk with Tatooine.
    // Adapter knows about which request should be sent and what type of data will be provided.

    public int? GetPopulation() => GetInformation<int?>("population");

    public double? GetCommerceIndex() => GetInformation<double?>("commerce_index");

    public double? GetPovertyIndex() => GetInformation<double?>("poverty_index");

    // Adapter transforms non-safety communication to safety
    private T? GetInformation<T>(string request)
    {
        try
        {
            return (T)_service.TrySendRequest(request);
        }
        catch
        {
            return default;
        }
    }
}
