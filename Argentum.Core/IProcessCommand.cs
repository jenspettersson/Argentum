namespace Argentum.Core
{
    public interface IProcessCommand
    {
        void Process(ICommand command);
    }
}