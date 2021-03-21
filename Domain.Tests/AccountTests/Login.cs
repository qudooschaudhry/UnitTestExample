using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tests.AccountTests
{
    public partial class Login : SpecificationBase
    {
        protected Account Account { get; set; }
        protected string Password { get; set; }
        protected bool Success { get; set; }
        protected override void Given()
        {
            Password = "p@ssw0rd";
            Account = Account.Register("Lady", "Gaga","ladygaga@mail.com",Password);
        }
    }
}
