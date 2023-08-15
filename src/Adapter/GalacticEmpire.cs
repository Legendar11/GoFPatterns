namespace Adapter;

internal class GalacticEmpire
{
    // Galactic Empire has Tatooin planet service as is
    private readonly TatooineService _tatooineService;

    public GalacticEmpire()
    {
        _tatooineService = new TatooineService(population: 250_000);

        _tatooineService.AddExported(1000);
        _tatooineService.AddImported(355);
    }

    public override string ToString()
    {
        // Galactic Empire talks with Tatooine only through special adapter because:
        // 1. Tatooine has too unsafe, unstable and old interface to communication,
        // 2. Galactic Empire talks to planets by uniform standard language,
        // 3. Adapter guarantees to provide safety data by standard way.

        var adapter = new TatooineServiceAdapter(_tatooineService);
        const string noData = "no data";

        var population = adapter.GetPopulation();
        var commerceIndex = adapter.GetCommerceIndex();
        var povertyIndex = adapter.GetPovertyIndex();

        return $"""
            Tatooine has:
                Population: {population?.ToString() ?? noData}
                Commerce index: {(commerceIndex is not null ? string.Format("{0:f4}", commerceIndex) : noData)}
                Poverty index: {(povertyIndex is not null ? string.Format("{0:f4}", povertyIndex) : noData)}
        """;
    }
}
