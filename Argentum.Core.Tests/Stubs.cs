namespace Argentum.Core.Tests
{
    public class TestCommand : ICommand { }

    public class TestCommandHandler : IHandleCommand<TestCommand>
    {
        public bool WasHandled { get; set; }

        public void HandleCommand(TestCommand command)
        {
            WasHandled = true;
        }
    }

    public class SecondTestCommandHandler : IHandleCommand<TestCommand>
    {
        public void HandleCommand(TestCommand command) { }
    }

    public class TestQuery : IQuery<bool> { }

    public class TestQueryHandler : IHandleQuery<TestQuery, bool>
    {
        public bool HandleQuery(TestQuery query)
        {
            return true;
        }
    }
    
    public class SecondTestQueryHandler : IHandleQuery<TestQuery, bool>
    {
        public bool HandleQuery(TestQuery query)
        {
            return true;
        }
    } 
}