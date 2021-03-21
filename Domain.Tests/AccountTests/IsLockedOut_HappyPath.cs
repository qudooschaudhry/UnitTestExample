using Xunit;

namespace Domain.Tests.AccountTests
{
    public partial class IsLockedOut
    {
        public class IsLockedOut_HappyPath : IsLockedOut
        {
            protected override void Given()
            {
                base.Given();
                Threshold = 5;
                LockoutDurationInMinutes = 5;
            }

            protected override void When()
            {
                AccountIsLocked = Account.IsLockedOut(Threshold, LockoutDurationInMinutes);
            }

            [Fact]
            public void ThenTheAccountIsNotLocked()
            {
                Assert.False(AccountIsLocked);
            }
        }
    }


}
