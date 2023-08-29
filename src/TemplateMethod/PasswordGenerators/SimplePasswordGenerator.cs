using System.Reflection.Emit;
using System.Security.Cryptography;

namespace TemplateMethod.PasswordGenerators;

internal class SimplePasswordGenerator : PasswordGenerator
{
    private RandomNumberGenerator? _generator;

    protected override char[] GenerateAlphabet()
    {
        return "abcdefghijklmnopqrstuvwxyz0123456789".ToArray();
    }

    protected override int GetLength()
    {
        return 8;
    }

    protected override RandomNumberGenerator GetRandomGenerator()
    {
        _generator = RandomNumberGenerator.Create();
        return _generator;
    }

    public override void Dispose()
    {
        _generator?.Dispose();
    }
}
