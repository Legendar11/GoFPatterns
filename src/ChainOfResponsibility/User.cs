namespace ChainOfResponsibility;

public record User(
    string Id,
    string Name,
    string Phone,
    string Country,
    string RegistrationNumber
)
{
    public bool IsInEuCountry() => new[]
    {
        "Germany",
        "Greece",
        "Italy",
        "Slovenia",
        "Poland"
    }.Any(c => c.ToLowerInvariant() == Country.ToLowerInvariant());
}
