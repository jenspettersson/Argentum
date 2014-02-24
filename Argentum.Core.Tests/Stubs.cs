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

    public class TestQuery : IQuery<bool> { }

    public class TestQueryHandler : IHandleQuery<TestQuery, bool>
    {
        public bool HandleQuery(TestQuery query)
        {
            return true;
        }
    }

    public interface IInterface {}

    public class ImplementationOne : IInterface{}
    public class ImplementationTwo : IInterface{}
}