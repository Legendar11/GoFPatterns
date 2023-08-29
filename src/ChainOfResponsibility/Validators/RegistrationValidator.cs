namespace ChainOfResponsibility.Validators;

internal class RegistrationValidator : Validator<User>
{
    public bool IsEmptyRegistrationAllowed { get; set; }

    public RegistrationValidator(bool isEmptyRegistrationAllowed)
    {
        IsEmptyRegistrationAllowed = isEmptyRegistrationAllowed;
    }

    public override (bool, string?) GetValidationResult(User value)
    {
        Console.WriteLine($"{nameof(RegistrationValidator)} is executed");

        if (!IsRegistrationValid(value.RegistrationNumber))
        {
            return (false, "Registration check is failed");
        }

        return NextValidator is null
            ? (true, null)
            : NextValidator.GetValidationResult(value);
    }

    private bool IsRegistrationValid(string registrationNumber)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
        {
            return IsEmptyRegistrationAllowed;
        }

        return registrationNumber.Length > 5;
    }
}
