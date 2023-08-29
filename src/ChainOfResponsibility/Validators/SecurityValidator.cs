namespace ChainOfResponsibility.Validators;

internal class SecurityValidator : Validator<User>
{
    public override (bool, string?) GetValidationResult(User value)
    {
        Console.WriteLine($"{nameof(SecurityValidator)} is executed");

        if (!IsAccessAllowed(value))
        {
            return (false, "Security check is failed");
        }

        return NextValidator is null
            ? (true, null)
            : NextValidator.GetValidationResult(value);
    }

    // mock method
    private static bool IsAccessAllowed(User value)
    {
        return true;
    }
}
