using System.Security.Cryptography;

namespace TemplateMethod;

internal abstract class PasswordGenerator : IPasswordGenerator
{
    /// <summary>
    /// An algorithm with abstract basic steps.
    /// </summary>
    public string Generate()
    {
        char[] alphabet = GenerateAlphabet(); // successor will provide it
        int length = GetLength(); // successor will provide it
        RandomNumberGenerator randomGenerator = GetRandomGenerator(); // successor will provide it

        byte[] bytes = new byte[length * 8];
        randomGenerator.GetBytes(bytes);

        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            ulong value = BitConverter.ToUInt64(bytes, i * 8);
            result[i] = alphabet[value % (uint)alphabet.Length];
        }

        return new string(result);
    }

    // Subclasses will implement next methods

    protected abstract char[] GenerateAlphabet();

    protected abstract int GetLength();

    protected abstract RandomNumberGenerator GetRandomGenerator();

    public abstract void Dispose();
}
