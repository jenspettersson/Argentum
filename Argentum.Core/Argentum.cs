using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    public class Argentum
    {
        //Todo: Temporary
        public static IMessageBus Initialize()
        {
            var callingAssembly = Assembly.GetCallingAssembly();

            TinyIoCContainer.Current.Register<IProcessCommand, DefaultCommandProcessor>();
            TinyIoCContainer.Current.Register<IProcessQuery, DefaultQueryProcessor>();


            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(callingAssembly, typeof(IHandleCommand<>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleQuery<,>));

            return new MessageBus();
        }
    }
}