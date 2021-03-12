namespace Domain
{
    public class HashProvider
    {
        internal static bool VerifyHash(string plainText, string hashedValue)
        {
            // do not use, this is just an example
            return Password.Create(plainText).HashValue == hashedValue;
        }
    }
}
