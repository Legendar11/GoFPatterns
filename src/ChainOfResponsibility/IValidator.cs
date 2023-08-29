namespace ChainOfResponsibility;

internal interface IValidator<T>
{
    /// <summary>
    /// The next handler who will will try to stop the process
    /// and provide the result. If it can't do it - it will pass to next handler.
    /// </summary>
    IValidator<T>? NextValidator { set; }

    /// <summary>
    /// Each successor implement their own version of method.
    /// In case validation is failed - the process stoped, we acquired the result.
    /// In case validation is successful - the process continue, we will get the result later.
    /// </summary>
    (bool, string?) GetValidationResult(T value);
}
