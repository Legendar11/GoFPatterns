namespace Builder;

internal class MontenegroAirlinesPassengerInfoBuilder : IPassengerInfoBuilder
{
    private string? _meal;
    private string? _selectedSeat;

    private string? _passengerFirstName;
    private string? _passengerLastName;

    /// <summary>
    /// Provide a simple full name parsing.
    /// </summary>
    public IPassengerInfoBuilder SetPassengerFullName(string fullName, string? separator = "_")
    {
        var values = fullName.Split(separator);

        _passengerFirstName = values[0];
        _passengerLastName = values[1];

        return this;
    }

    /// <summary>
    /// Allowed to add only one meal.
    /// </summary>
    public IPassengerInfoBuilder AddMeal(string meal)
    {
        _meal = meal;
        return this;
    }

    /// <summary>
    /// Wheelchair is not supported.
    /// </summary>
    public IPassengerInfoBuilder RequestWheelChair()
    {
        throw new NotSupportedException("Wheelchair is not supported for now");
    }

    public IPassengerInfoBuilder SetSeat(string number)
    {
        _selectedSeat = number;
        return this;
    }

    /// <summary>
    /// Simple validation with optional random seat selection.
    /// </summary>
    public PassengerInfo Build()
    {
        if (string.IsNullOrWhiteSpace(_passengerFirstName))
        {
            throw new NotSupportedException("Passenger first name is required");
        }
        if (string.IsNullOrWhiteSpace(_passengerLastName))
        {
            throw new NotSupportedException("Passenger last name is required");
        }

        var services = new List<(ServiceCategory, string?)>();

        if (!string.IsNullOrWhiteSpace(_selectedSeat))
        {
            services.Add((ServiceCategory.SeatSelection, _selectedSeat));
        }
        else
        {
            services.Add((ServiceCategory.SeatSelection, GetRandomSeat()));
        }

        if (!string.IsNullOrWhiteSpace(_meal))
        {
            services.Add((ServiceCategory.Meal, _meal));
        }

        return new PassengerInfo
        {
            FirstName = _passengerFirstName,
            LastName = _passengerLastName,
            Services = services
        };

        static string GetRandomSeat() => Guid.NewGuid().ToString().Substring(0, 2);
    }
}
