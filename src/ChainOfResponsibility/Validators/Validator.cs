namespace ChainOfResponsibility.Validators;

internal abstract class Validator<T> : IValidator<T>
{
    public IValidator<T>? NextValidator { protected get; set; }

    public abstract (bool, string?) GetValidationResult(T value);
}
