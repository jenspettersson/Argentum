namespace Argentum.Core
{
    public interface IHandleCommand<in TCommand> where TCommand : ICommand
    {
        void HandleCommand(TCommand command);
    }
}