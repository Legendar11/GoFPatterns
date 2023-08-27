namespace Builder;

internal record PassengerInfo(
    string FirstName,
    string? MiddleName,
    string LastName,
    string? Patronyc,
    List<(ServiceCategory Service, string? Desciption)> Services
)
{
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
