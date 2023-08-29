namespace ChainOfResponsibility.Validators;

internal class NameValidator : Validator<User>
{
    public override (bool, string?) GetValidationResult(User value)
    {
        Console.WriteLine($"{nameof(NameValidator)} is executed");

        if (!IsNameValid(value.Name))
        {
            return (false, "Name check is failed");
        }

        return NextValidator is null
            ? (true, null)
            : NextValidator.GetValidationResult(value);
    }

    private static bool IsNameValid(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }
}
