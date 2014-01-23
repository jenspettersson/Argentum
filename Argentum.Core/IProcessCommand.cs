namespace Argentum.Core
{
    public interface IProcessCommand
    {
        void Execute(ICommand command);
    }
}