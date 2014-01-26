using FluentAssertions;
using StructureMap;
using Xunit;
using Moq;
using TinyIoC;

namespace Argentum.Core.Tests
{ 
    public class TemporaryTests
    {
        [Fact]
        public void DefaultQueryProcessorTests_Stubbing_Container()
        {
            var container = new Mock<IContainer>();

            var handlerMock = new Mock<IHandleQuery<IQuery<bool>, bool>>();
            container.Setup(x => x.GetInstance(typeof (IHandleQuery<TestQuery, bool>))).Returns(handlerMock.Object);
            
            var defaultQueryProcessor = new DefaultQueryProcessor(container.Object);

            var testQuery = new TestQuery();
            defaultQueryProcessor.Process(testQuery);

            handlerMock.Verify(x => x.HandleQuery(testQuery), Times.Once);
        }

        [Fact]
        public void DefaultQueryProcessorTests_Not_Stubbing_Container()
        {
            var handlerMock = new Mock<IHandleQuery<TestQuery, bool>>();
            ObjectFactory.Configure(x => x.For<IHandleQuery<TestQuery, bool>>().Use(handlerMock.Object));

            var processor = new DefaultQueryProcessor(ObjectFactory.Container);

            var testQuery = new TestQuery();
            processor.Process(testQuery);

            handlerMock.Verify(x => x.HandleQuery(testQuery));
        }
    
        [Fact]
        public void DefaultQueryProcessorTests_No_Stubbing_At_all()
        {
            var testQueryHandler = new TestQueryHandler();
            ObjectFactory.Configure(x => x.For<IHandleQuery<TestQuery, bool>>().Use(testQueryHandler));

            var processor = new DefaultQueryProcessor(ObjectFactory.Container);

            var testQuery = new TestQuery();
            var wasProcessed = processor.Process(testQuery);

            wasProcessed.Should().BeTrue();
        }
    
        [Fact]
        public void TinyIOCQueryProcessorTests_Not_Stubbing_Container()
        {
            var handlerMock = new Mock<IHandleQuery<TestQuery, bool>>();
            TinyIoCContainer.Current.Register(handlerMock.Object);

            var processor = new TinyIOCQueryProcessor();

            var testQuery = new TestQuery();
            processor.Process(testQuery);

            handlerMock.Verify(x => x.HandleQuery(testQuery));
        }

        [Fact]
        public void TinyIOCQueryProcessorTests_No_Stubbing_At_All()
        {
            var testQueryHandler = new TestQueryHandler();
            TinyIoCContainer.Current.Register<IHandleQuery<TestQuery, bool>>(testQueryHandler);

            var processor = new TinyIOCQueryProcessor();

            var wasProcessed = processor.Process(new TestQuery());

            wasProcessed.Should().BeTrue();
        }
    }
    
    public class TestQuery : IQuery<bool> {}

    public class TestQueryHandler : IHandleQuery<TestQuery, bool>
    {
        public bool HandleQuery(TestQuery query)
        {
            return true;
        }
    }
}
