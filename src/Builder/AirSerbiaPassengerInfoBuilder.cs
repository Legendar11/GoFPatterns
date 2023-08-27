namespace Builder;

internal class AirSerbiaPassengerInfoBuilder : IPassengerInfoBuilder
{
    private List<string> _meals = new List<string>();
    private bool _isWheelChairRequired;
    private string? _selectedSeat;

    private string? _passengerFirstName;
    private string? _passengerLastName;
    private string? _passengerMiddleName;
    private string? _passengerPatronyc;

    /// <summary>
    /// Provide a complex full name parsing.
    /// </summary>
    public IPassengerInfoBuilder SetPassengerFullName(string fullName, string? separator = "_")
    {
        separator ??= ";";

        var values = fullName.Split(separator);

        _passengerFirstName = values[0];
        _passengerLastName = values[1];
        _passengerMiddleName = values.Length > 2 ? values[2] : null;
        _passengerPatronyc = values.Length > 3 ? values[3] : null;

        return this;
    }

    /// <summary>
    /// Allowed to add several meals.
    /// </summary>
    public IPassengerInfoBuilder AddMeal(string meal)
    {
        _meals.Add(meal);
        return this;
    }

    /// <summary>
    /// Wheelchair is supported.
    /// </summary>
    public IPassengerInfoBuilder RequestWheelChair()
    {
        _isWheelChairRequired = true;
        return this;
    }

    public IPassengerInfoBuilder SetSeat(string number)
    {
        _selectedSeat = number;
        return this;
    }

    /// <summary>
    /// Complex validation with required seat selection.
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
        if (string.IsNullOrWhiteSpace(_selectedSeat))
        {
            throw new NotSupportedException("Passenger must select a seat");
        }

        var services = new List<(ServiceCategory, string?)>();

        if (!string.IsNullOrWhiteSpace(_selectedSeat))
        {
            services.Add((ServiceCategory.SeatSelection, _selectedSeat));
        }
        if (_isWheelChairRequired)
        {
            services.Add((ServiceCategory.WheelChair, default));
        }
        foreach (var meal in _meals)
        {
            services.Add((ServiceCategory.Meal, meal));
        }

        return new PassengerInfo(
            _passengerFirstName,
            _passengerMiddleName,
            _passengerLastName,
            _passengerPatronyc,
            services
        );
    }
}
