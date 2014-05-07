using FluentAssertions;
using TinyIoC;
using Xunit;

namespace Argentum.Core.Tests
{
    public class DefaultCommandProcessorTests : IUseFixture<ContainerFixture>
    {
        [Fact]
        public void Should_process_registered_command()
        {
            var testCommandHandler = new TestCommandHandler();
            TinyIoCContainer.Current.Register<IHandleCommand<TestCommand>>(testCommandHandler);

            var processor = new DefaultCommandProcessor();

            processor.Process(new TestCommand());

            testCommandHandler.WasHandled.Should().BeTrue();
        }

        public void SetFixture(ContainerFixture data)
        {
            data.ClearContainer();
        }
    }
}