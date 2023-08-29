using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Validators;

internal class PhoneValidator : Validator<User>
{
    public override (bool, string?) GetValidationResult(User value)
    {
        Console.WriteLine($"{nameof(PhoneValidator)} is executed");

        if (!IsPhoneValid(value.Phone))
        {
            return (false, "Phone check is failed");
        }

        return NextValidator is null
            ? (true, null)
            : NextValidator.GetValidationResult(value);
    }

    private static bool IsPhoneValid(string phone)
    {
        return Regex.IsMatch(phone, @"^(\+[0-9]{9})$");
    }
}
