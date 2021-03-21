using System;
using Xunit;

namespace Domain.Tests
{
    public abstract class SpecificationBase
    {
        protected virtual void Given() { }
        protected virtual void When() { }
        
        public SpecificationBase()
        {
            Given();
            When();
        }
    }
}
