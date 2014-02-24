using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    public interface IArgentum
    {
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

            return new Argentum(new DefaultCommandProcessor(), new DefaultQueryProcessor());
        }

        private readonly IProcessCommand _commandProcessor;
        private readonly IProcessQuery _queryProcessor;

        public Argentum(IProcessCommand commandProcessor, IProcessQuery queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

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