using Xunit;

namespace Argentum.Core.Tests
{    
    public class SomeTestClass : IUseFixture<TestSetupFixture>
    {
        [Fact]
        public void SomeTest()
        {
            
        }

        public void SetFixture(TestSetupFixture data)
        {
            data.DoStuff();
        }
    }

    public class TestSetupFixture
    {
        public void DoStuff()
        {
            
        }
    }
}
