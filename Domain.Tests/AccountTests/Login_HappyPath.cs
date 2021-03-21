using Xunit;

namespace Domain.Tests.AccountTests
{
    public partial class Login
    {
        public class Login_HappyPath : Login
        {
            protected override void When()
            {
                Success = Account.Login(Password);
            }

            [Fact]
            protected void ThenLoginIsSuccessfulWhenCorrectPasswordIsProvided()
            {
                Assert.True(Success);
            }
        }
    }
}
