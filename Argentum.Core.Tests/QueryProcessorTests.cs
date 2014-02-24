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

        public void SetFixture(ContainerFixture data)
        {
            data.ClearContainer();
        }
    }
}
