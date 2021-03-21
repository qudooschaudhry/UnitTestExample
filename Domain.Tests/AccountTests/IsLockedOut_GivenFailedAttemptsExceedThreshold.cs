using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests.AccountTests
{
    public partial class IsLockedOut
    {
        public class IsLockedOut_GivenFailedAttemptsExceedThreshold : IsLockedOut
        {
            protected override void Given()
            {
                base.Given();
                Account.Attempts = new List<LoginAttempt>()
                {
                    new LoginAttempt(){ Account = Account, Success = false, AttemptTimeStampUtc = DateTimeOffset.UtcNow.AddMinutes(-1) },
                    new LoginAttempt(){ Account = Account, Success = false, AttemptTimeStampUtc = DateTimeOffset.UtcNow.AddMinutes(-1) },
                    new LoginAttempt(){ Account = Account, Success = false, AttemptTimeStampUtc = DateTimeOffset.UtcNow.AddMinutes(-1) },
                    new LoginAttempt(){ Account = Account, Success = false, AttemptTimeStampUtc = DateTimeOffset.UtcNow.AddMinutes(-1) },
                    new LoginAttempt(){ Account = Account, Success = false, AttemptTimeStampUtc = DateTimeOffset.UtcNow.AddMinutes(-1) },
                };

                Threshold = 5;
                LockoutDurationInMinutes = 5;
            }

            protected override void When()
            {
                AccountIsLocked = Account.IsLockedOut(Threshold, LockoutDurationInMinutes);
            }

            [Fact]
            public void ThenTheAccountIsLocked()
            {
                Assert.True(AccountIsLocked);
            }
        }
    }


}
