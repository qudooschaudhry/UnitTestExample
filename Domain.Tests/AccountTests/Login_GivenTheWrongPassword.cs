using Xunit;

namespace Domain.Tests.AccountTests
{
    public partial class Login
    {
        public class Login_GivenTheWrongPassword : Login
        {
            protected override void Given()
            {
                base.Given();
                Password = "incorrectpassword";
            }
            protected override void When()
            {
                Success = Account.Login(Password);
            }

            [Fact]
            protected void ThenLoginIsNotSuccessful()
            {
                Assert.False(Success);
            }
        }
    }
}
