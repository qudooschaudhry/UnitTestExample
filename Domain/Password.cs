namespace Domain
{
    public class Password
    {
        public string HashValue { get; set; }
        internal static Password Create(string plainText)
        {
            return new Password()
            {
                // do not do this, this is just an example
                HashValue = $"{plainText}_hashedvalue"
            };
        }

        internal bool IsMatch(string plainText)
        {
            return HashProvider.VerifyHash(plainText, HashValue);
        }
    }
}
