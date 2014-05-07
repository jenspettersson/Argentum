using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    public interface IArgentum
    {
        void Raise(IEvent evt);
        void Process(ICommand command);
        TResult Process<TResult>(IQuery<TResult> query);
    }

    public class Argentum : IArgentum
    {
        //Todo: Temporary
        public static IArgentum Initialize()
        {
            var callingAssembly = Assembly.GetCallingAssembly();

            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(callingAssembly, typeof(IHandleCommand<>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleQuery<,>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleEvent<>), allowMultipleImplementations: true);

            return new Argentum(new DirectBus(), new DefaultQueryProcessor(), new DefaultEventRaiser());
        }

        private readonly IProcessCommand _commandProcessor;
        private readonly IProcessQuery _queryProcessor;
        private readonly IRaiseEvent _eventRaiser;

        public Argentum(IProcessCommand commandProcessor, IProcessQuery queryProcessor, IRaiseEvent eventRaiser)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
            _eventRaiser = eventRaiser;
        }

        public void Raise(IEvent evt)
        {
            _eventRaiser.Raise(evt);
        }

        public void Process(ICommand command)
        {
            _commandProcessor.Process(command);

            _commandProcessor.Commit();
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            return _queryProcessor.Process(query);
        }
    }
}