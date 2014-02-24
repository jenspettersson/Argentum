using System;
using System.Collections.Generic;
using System.Linq;
using TinyIoC;

namespace Argentum.Core
{
    public class DefaultQueryProcessor : IProcessQuery
    {
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IHandleQuery<,>).MakeGenericType(query.GetType(), typeof(TResult));

            IEnumerable<dynamic> registeredHandlers = TinyIoCContainer.Current.ResolveAll(handlerType, includeUnnamed: true);

            var handlers = registeredHandlers as dynamic[] ?? registeredHandlers.ToArray();
            
            if(!handlers.Any())
                throw new NoQueryHandlerFoundException(string.Format("No handler was registered for query {0}", query.GetType().FullName));

            return handlers[0].HandleQuery((dynamic)query);
        }
    }

    public class NoQueryHandlerFoundException : Exception
    {
        public NoQueryHandlerFoundException(string message) : base(message) { }
    }
}