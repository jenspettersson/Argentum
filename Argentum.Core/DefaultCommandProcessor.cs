using TinyIoC;

namespace Argentum.Core
{
	public class DefaultCommandProcessor : IProcessCommand
	{
		private readonly TinyIoCContainer container;

		public DefaultCommandProcessor(TinyIoCContainer container)
		{
			this.container = container;
		}

		public void Process(ICommand command)
		{
			var handlerType = typeof (IHandleCommand<>).MakeGenericType(command.GetType());
			dynamic handler = container.Resolve(handlerType);

			handler.HandleCommand((dynamic) command);
		}
	}
}