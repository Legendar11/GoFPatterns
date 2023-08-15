namespace Builder;

/// <summary>
/// Builder allows to create complex object by optional steps.
/// Pattern allows to encapsualte logic of creation from final result.
/// Different builders will create same object with different representation.
/// </summary>
internal interface IPassengerInfoBuilder
{
    IPassengerInfoBuilder SetPassengerFullName(string fullName, string? separator = "_");

    IPassengerInfoBuilder AddMeal(string meal);

    IPassengerInfoBuilder RequestWheelChair();

    IPassengerInfoBuilder SetSeat(string number);

    PassengerInfo Build();
}
