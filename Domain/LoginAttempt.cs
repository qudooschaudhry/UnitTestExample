using System;

namespace Domain
{
    public class LoginAttempt
    {
        public Account Account { get; set; }
        public bool Success { get; set; }
        public DateTimeOffset AttemptTimeStampUtc { get; set; }

        public static LoginAttempt LogAnAttempt(
            Account account, 
            bool success)
        {
            return new LoginAttempt()
            {
                Account = account,
                Success = success,
                AttemptTimeStampUtc = DateTimeOffset.UtcNow
            };
        }

    }
}
