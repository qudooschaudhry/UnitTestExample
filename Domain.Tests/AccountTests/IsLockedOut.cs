using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests.AccountTests
{
    public partial class IsLockedOut : SpecificationBase
    {
        protected Account Account { get; set; }
        protected int Threshold { get; set; }
        protected int LockoutDurationInMinutes { get; set; }
        protected bool AccountIsLocked { get; set; }

        protected override void Given()
        {
            Account = Account.Register("Lady", "Gaga", "ladygaga@mail.com", "p@ssw0rd");
        }
    }


}
