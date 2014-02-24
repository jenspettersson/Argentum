using TinyIoC;

namespace Argentum.Core
{
    public interface IMessageBus
    {
        void Process(ICommand command);
        TResult Process<TResult>(IQuery<TResult> query);
    }

    public class MessageBus : IMessageBus
    {
        public void Process(ICommand command)
        {
            TinyIoCContainer.Current.Resolve<IProcessCommand>().Process(command);
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            return TinyIoCContainer.Current.Resolve<IProcessQuery>().Process(query);
        }
    }
}