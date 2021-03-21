using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Account Register(
            string firstName,
            string lastName,
            string email, 
            string password)
        {
            return new Account()
            {
                Id = Guid.NewGuid(),
                FirstName = "Lady",
                LastName = "Gaga",
                Email = "ladygaga@mail.com",
                Password = Password.Create(password)
            };
        }

        public bool Login(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var isMatch = Password.IsMatch(password);

            // log this attempt
            Attempts.Add(LoginAttempt.LogAnAttempt(this, isMatch));

            return isMatch;
        }

        public bool IsLockedOut(int threshold, int lockoutDurationInMinutes)
        {
            var lastLoginAttempt = Attempts.OrderByDescending(a => a.AttemptTimeStampUtc).FirstOrDefault();

            // check if this is first login or if last login was successful
            if (lastLoginAttempt == null || lastLoginAttempt.Success)
                return false;

            // check if lockout duration has passed
            var timeStamp = DateTimeOffset.UtcNow;
            if ((timeStamp - lastLoginAttempt.AttemptTimeStampUtc).TotalMinutes > lockoutDurationInMinutes)
                return false;

            var attemptsWithinLockoutDuration
                = Attempts
                .OrderByDescending(a => a.AttemptTimeStampUtc)
                .Where(a => (timeStamp - a.AttemptTimeStampUtc).TotalMinutes <= lockoutDurationInMinutes)
                .Take(threshold);

            // reached the threshold and none of them are successful. 
            return attemptsWithinLockoutDuration.Count() == threshold && !attemptsWithinLockoutDuration.Any(a => a.Success); ;
        }
    }
}
