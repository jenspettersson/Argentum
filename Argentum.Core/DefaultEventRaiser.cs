using System;
using TinyIoC;

namespace Argentum.Core
{
    public class DefaultEventRaiser : IRaiseEvent
    {
        public void Raise(IEvent evt)
        {
            Type handlerType = typeof(IHandleEvent<>).MakeGenericType(evt.GetType());

            dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);

            handler.HandleEvent((dynamic) evt);
        }
    }
}