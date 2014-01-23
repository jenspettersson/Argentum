using FluentAssertions;
using StructureMap;
using Xunit;

namespace Argentum.Core.Tests
{    
    public class DefaultQueryProcessorTests
    {
        [Fact]
        public void Process_should_process_registered_query_with_handler()
        {
            //Todo: Mock container

            var defaultQueryProcessor = new DefaultQueryProcessor(ObjectFactory.Container);

            bool wasProcessed = defaultQueryProcessor.Process(new TestQuery());

            wasProcessed.Should().BeTrue();
        }
    }

    public class TestQueryHandler : IHandleQuery<TestQuery, bool>
    {
        public bool HandleQuery(TestQuery query)
        {
            return true;
        }
    }

    public class TestQuery : IQuery<bool>
    {
        
    }
}
