using StructureMap;

namespace Argentum.Core
{
	public class DefaultCommandProcessor : IProcessCommand
	{
		private readonly IContainer _container;

		public DefaultCommandProcessor(IContainer container)
		{
			this._container = container;
		}

		public void Process(ICommand command)
		{
			var handlerType = typeof (IHandleCommand<>).MakeGenericType(command.GetType());
		    dynamic handler = _container.GetInstance(handlerType);

			handler.HandleCommand((dynamic) command);
		}
	}
}