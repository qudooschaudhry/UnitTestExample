using System;
using Xunit;

namespace Domain.Tests.AccountTests
{
    public partial class Login
    {
        public class Login_GivenNoPasswordProvided : Login
        {
            [Fact]
            protected void ThenAnExceptionIsThrown()
            {
                _ = Assert.Throws<ArgumentNullException>(() => Account.Login("")); ;
            }

        }
    }
}
