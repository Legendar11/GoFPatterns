namespace TemplateMethod;

internal interface IPasswordGenerator : IDisposable
{
    public string Generate();
}
