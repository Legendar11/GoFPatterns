using System.Security.Cryptography;

namespace TemplateMethod.PasswordGenerators;

internal class StrongPasswordGenerator : PasswordGenerator
{
    private RandomNumberGenerator? _generator;

    protected override char[] GenerateAlphabet()
    {
        const string lower = "abcdefghijklmnopqrstuvwxyz";
        const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string number = "1234567890";
        const string special = "!@#$%^&*_-=+";

        return (lower + upper + number + special).ToArray();
    }

    protected override int GetLength()
    {
        return 24;
    }

    protected override RandomNumberGenerator GetRandomGenerator()
    {
        _generator = new RNGCryptoServiceProvider();
        return _generator;
    }

    public override void Dispose()
    {
        _generator?.Dispose();
    }
}