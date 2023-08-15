namespace Builder;

internal record PassengerInfo
{
    public string FirstName { get; init; } = null!;

    public string? MiddleName { get; init; }

    public string LastName { get; init; } = null!;

    public string? Patronyc { get; init; }

    public List<(ServiceCategory Service, string? Desciption)> Services { get; init; } = new List<(ServiceCategory Service, string? Desciption)>();

    public override string ToString()
    {
        return $"""

            First name: {FirstName}
            Middle name: {MiddleName}
            Last name: {LastName}
            Patronyc: {Patronyc}
            Services: {string.Join(", ", Services.Select(s =>
                $"{s.Service}{(!string.IsNullOrWhiteSpace(s.Desciption) ? $": {s.Desciption}" : "")}"))}

        """;
    }
}
