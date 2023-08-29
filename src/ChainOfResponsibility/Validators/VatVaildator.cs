using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Validators;

internal class VatVaildator : Validator<User>
{
    public override (bool, string?) GetValidationResult(User value)
    {
        Console.WriteLine($"{nameof(VatVaildator)} is executed");

        if (!IsVatValid(value.Country, value.RegistrationNumber))
        {
            return (false, "Vat check is failed");
        }

        return NextValidator is null
            ? (true, null)
            : NextValidator.GetValidationResult(value);
    }

    private static bool IsVatValid(string country, string registrationNumber)
    {
        return country.ToLowerInvariant() switch
        {
            "germany" => Regex.IsMatch("(DE)?[0-9]{9}", registrationNumber),
            "greece" => Regex.IsMatch("(EL)?[0-9]{9}", registrationNumber),
            "italy" => Regex.IsMatch("(IT)?[0-9]{11}", registrationNumber),
            "slovenia" => Regex.IsMatch("(SI)?[0-9]{8}", registrationNumber),
            "poland" => Regex.IsMatch("(PL)?[0-9]{10}", registrationNumber),
            _ => false
        };
    }
}
