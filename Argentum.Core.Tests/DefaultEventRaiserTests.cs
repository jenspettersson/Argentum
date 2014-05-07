using FluentAssertions;
using TinyIoC;
using Xunit;

namespace Argentum.Core.Tests
{
    public class DefaultEventRaiserTests : IUseFixture<ContainerFixture>
    {
        [Fact]
        public void Should_invoke_registered_event_handler()
        {
            var testEventHandler = new TestEventHandler();
            TinyIoCContainer.Current.Register<IHandleEvent<TestEvent>>(testEventHandler);

            var eventRaiser = new DefaultEventRaiser();
            eventRaiser.Raise(new TestEvent());

            testEventHandler.WasHandled.Should().BeTrue();
        }

        public void SetFixture(ContainerFixture data)
        {
            data.ClearContainer();
        }
    }
}