using TinyIoC;

namespace Argentum.Core.Tests
{
    public class ContainerFixture
    {
        public void ClearContainer()
        {
            TinyIoCContainer.Current.ClearAll();
        }
    }
}