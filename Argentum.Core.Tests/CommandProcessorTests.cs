using FluentAssertions;
using TinyIoC;
using Xunit;

namespace Argentum.Core.Tests
{
    public class CommandProcessorTests : IUseFixture<ContainerFixture>
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

        [Fact]
        public void Should_throw_if_no_command_handler_are_registered_for_given_command()
        {
            var processor = new DefaultCommandProcessor();

            Assert.Throws<NoCommandHandlerFoundException>(() => processor.Process(new TestCommand()));
        }

        public void SetFixture(ContainerFixture data)
        {
            data.ClearContainer();
        }
    }
}