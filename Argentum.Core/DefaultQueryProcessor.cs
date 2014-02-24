using System;
using TinyIoC;

namespace Argentum.Core
{
    public class DefaultQueryProcessor : IProcessQuery
    {
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IHandleQuery<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);

            return handler.HandleQuery((dynamic)query);
        }
    }
}