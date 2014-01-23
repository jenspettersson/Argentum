using System;
using StructureMap;

namespace Argentum.Core
{
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
}