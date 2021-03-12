using System;
using System.Collections.Generic;

namespace Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; }
        public List<LoginAttempt> Attempts { get; set; } = new List<LoginAttempt>();

        public bool Login(string password)
        {
            var isMatch = Password.IsMatch(password);

            // log this attempt
            Attempts.Add(LoginAttempt.LogAnAttempt(this, isMatch));

            return isMatch;
        }

        public bool IsLockedOut(int attemptsThreshold, int lockoutDurationInMinutes)
        {
            return true;
        }
    }
}
