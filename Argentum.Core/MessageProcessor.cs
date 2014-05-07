using System;
using TinyIoC;

namespace Argentum.Core
{
    public class MessageProcessor : IProcessMessages
    {
        public void Process(ICommand command)
        {
            dynamic handler = GetHandler(command, typeof(IHandleCommand<>));

            handler.HandleCommand((dynamic)command);
        }

        public void Process(IEvent evt)
        {
            dynamic handler = GetHandler(evt, typeof(IHandleEvent<>));

            handler.HandleCommand((dynamic)evt);
        }

        private static dynamic GetHandler(object message, Type type)
        {
            Type handlerType = type.MakeGenericType(message.GetType());

            dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);
            return handler;
        }
    }
}