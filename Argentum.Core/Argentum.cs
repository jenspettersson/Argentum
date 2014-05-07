using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    public interface IArgentum
    {
    }

    public class Argentum : IArgentum
    {
        public static IBus Initialize()
        {
            var callingAssembly = Assembly.GetCallingAssembly();

            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(callingAssembly, typeof(IHandleCommand<>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleQuery<,>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleEvent<>), allowMultipleImplementations: true);

            TinyIoCContainer.Current.Register<IProcessMessages, MessageProcessor>().AsSingleton();
            TinyIoCContainer.Current.Register<IBus, DirectBus>().AsSingleton();

            return TinyIoCContainer.Current.Resolve<IBus>();
        }
    }
}