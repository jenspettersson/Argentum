namespace Argentum.Core
{
    public interface IBus
    {
        void Process(ICommand command);
        TResult Process<TResult>(IQuery<TResult> query);
    }

    public class Bus : IBus
    {
        private readonly IProcessCommand _commandProcessor = new DefaultCommandProcessor();
        private readonly IProcessQuery _queryProcessor = new DefaultQueryProcessor();

        public void Process(ICommand command)
        {
            _commandProcessor.Process(command);
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            return _queryProcessor.Process(query);
        }
    }
}