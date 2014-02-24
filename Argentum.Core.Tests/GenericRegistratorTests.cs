using System.Linq;
using System.Reflection;
using FluentAssertions;
using TinyIoC;
using Xunit;

namespace Argentum.Core.Tests
{
    public class GenericRegistratorTests
    {
        [Fact]
        public void Should_register_all_command_handlers_from_given_assembly()
        {
            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(typeof(TestCommandHandler).Assembly, typeof(IHandleCommand<>));

            var commandHandler = TinyIoCContainer.Current.Resolve<IHandleCommand<TestCommand>>();

            commandHandler.GetType().Should().Be<TestCommandHandler>();
        }

        [Fact]
        public void Should_register_all_query_handlers_from_given_assembly()
        {
            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(typeof(TestQueryHandler).Assembly, typeof(IHandleQuery<,>));

            var queryHandler = TinyIoCContainer.Current.Resolve<IHandleQuery<TestQuery, bool>>();
            queryHandler.GetType().Should().Be<TestQueryHandler>();
        }

        [Fact]
        public void Should_throw_if_trying_to_register_multiple_implementations_when_not_allowed()
        {
            var registrator = new GenericRegistrator();

            Assert.Throws<MultipleImplementaionsNotAllowedException>(() => 
                registrator.RegisterFrom(typeof(ImplementationOne).Assembly, typeof(IInterface)));
        }

        [Fact]
        public void Should_register_multiple_implementations_when_allowed()
        {
            var registrator = new GenericRegistrator();

            registrator.RegisterFrom(typeof (ImplementationOne).Assembly, typeof (IInterface), allowMultipleImplementations: true);

            TinyIoCContainer.Current.ResolveAll<IInterface>().Should().HaveCount(2);
        }
    }
}