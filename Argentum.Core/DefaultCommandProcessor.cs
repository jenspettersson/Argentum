using System;
using TinyIoC;
namespace Argentum.Core
{
    public class DefaultCommandProcessor : IProcessCommand
	{
		public void Process(ICommand command)
		{
            Type handlerType = typeof(IHandleCommand<>).MakeGenericType(command.GetType());

            dynamic handler = TinyIoCContainer.Current.Resolve(handlerType);

            handler.HandleCommand((dynamic)command);
		}
	}
}