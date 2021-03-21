namespace Domain
{
    public class HashProvider
    {
        public static string Hash(string plainText)
        {
            return $"{plainText}_hashedvalue";
        }
        public static bool VerifyHash(string plainText, string hashedValue)
        {
            // do not use, this is just an example
            return Password.Create(plainText).HashValue == hashedValue;
        }
    }
}
