using System;
using StructureMap;

namespace Argentum.Core
{
    using TinyIoC;

    public class DefaultQueryProcessor : IProcessQuery
    {
        private readonly IContainer _container;

        public DefaultQueryProcessor(IContainer container)
        {
            _container = container;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IHandleQuery<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _container.GetInstance(handlerType);

            return handler.HandleQuery((dynamic)query);
        }
    }

    public class TinyIOCQueryProcessor : IProcessQuery
    {
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IHandleQuery<,>).MakeGenericType(query.GetType(), typeof(TResult));
            
            dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);

            return handler.HandleQuery((dynamic) query);
        }
    }
}