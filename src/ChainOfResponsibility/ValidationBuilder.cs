namespace ChainOfResponsibility;

internal class ValidationBuilder<T>
{
    IValidator<T>? _first, _last;

    public ValidationBuilder<T> Add(IValidator<T> validator)
    {
        if (_first is null)
        {
            _first = validator;
            _last = validator;
        }
        else
        {
            _last!.NextValidator = validator;
            _last = validator;
        }

        return this;
    }

    public IValidator<T>? Build() => _first;
}
