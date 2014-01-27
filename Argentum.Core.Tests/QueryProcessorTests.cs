using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TinyIoC;

namespace Argentum.Core.Tests
{
    public class QueryProcessorTests : IUseFixture<ContainerFixture>
    {
        [Fact]
        public void Should_process_registered_query()
        {
            var testQueryHandler = new TestQueryHandler();
            TinyIoCContainer.Current.Register<IHandleQuery<TestQuery, bool>>(testQueryHandler);

            var processor = new DefaultQueryProcessor();

            var wasProcessed = processor.Process(new TestQuery());

            wasProcessed.Should().BeTrue();
        }

        [Fact]
        public void Should_throw_if_no_query_handler_are_registered_for_given_query()
        {
            var processor = new DefaultQueryProcessor();

            Assert.Throws<NoQueryHandlerFoundException>(() => processor.Process(new TestQuery()));
        }

        [Fact]
        public void Should_throw_if_multiple_query_handlers_are_registered_for_given_query()
        {

            TinyIoCContainer.Current.RegisterMultiple<IHandleQuery<TestQuery, bool>>(new List<Type>
                {
                    typeof(TestQueryHandler),
                    typeof(SecondTestQueryHandler)
                });
            

            var processor = new DefaultQueryProcessor();

            Assert.Throws<MultipleQueryHandlersNotSupportedException>(() => processor.Process(new TestQuery()));
        }

        public void SetFixture(ContainerFixture data)
        {
            data.ClearContainer();
        }
    }
}
