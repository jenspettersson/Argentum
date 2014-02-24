using System;
using System.Collections.Generic;
using System.Linq;
using TinyIoC;

namespace Argentum.Core
{
	public class DefaultCommandProcessor : IProcessCommand
	{
		public void Process(ICommand command)
		{
            Type handlerType = typeof(IHandleCommand<>).MakeGenericType(command.GetType());

            IEnumerable<dynamic> registeredHandlers = TinyIoCContainer.Current.ResolveAll(handlerType, includeUnnamed: true);

            var handlers = registeredHandlers as dynamic[] ?? registeredHandlers.ToArray();

            if (!handlers.Any())
                throw new NoCommandHandlerFoundException(string.Format("No handler was registered for command {0}", command.GetType().FullName));
            
            handlers[0].HandleCommand((dynamic)command);
		}
	}

    public class MultipleCommandHandlersNotSupportedException : Exception
    {
        public MultipleCommandHandlersNotSupportedException(string message) : base(message) { }
    }

    public class NoCommandHandlerFoundException : Exception
    {
        public NoCommandHandlerFoundException(string message) : base(message) { }
    }
}