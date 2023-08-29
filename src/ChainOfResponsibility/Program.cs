using ChainOfResponsibility;
using ChainOfResponsibility.Validators;

// Software design pattern Chain of Responsibility:
// Avoid binding the sender of a request to its recipient by letting the source material process the request. binds
// receiver objects in the chain and pass the request along this chain until it will not process.
// The main purpose:
// Decouple the process of algorithm, separating of each step into separated class.
// Additional benefit:
// The chain of handlers can be configured, instead of strict inherition.

User user = new User(Guid.NewGuid().ToString(), "Alfredo James (Al) Pacino", "+3817275480", "USA", "GR1115553332");

// Pattern allows to provide flexible  way to set next handlers (validators).
// For achieving  it - we can implement Builder pattern.

var builder = new ValidationBuilder<User>()
    .Add(new SecurityValidator())
    .Add(new NameValidator());
if (user.IsInEuCountry())
{
    builder = builder.Add(new VatVaildator());
}
else
{
    builder = builder.Add(new RegistrationValidator(isEmptyRegistrationAllowed: true));
}
builder = builder.Add(new PhoneValidator());

var validator = builder.Build()!;

Console.WriteLine($"{Environment.NewLine}Validation result: {validator.GetValidationResult(user)}");

