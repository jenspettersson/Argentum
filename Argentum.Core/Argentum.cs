using System.Reflection;
using TinyIoC;

namespace Argentum.Core
{
    public class Argentum
    {
        public IProcessCommand CommandProcessor { get { return TinyIoCContainer.Current.Resolve<IProcessCommand>(); } }
        public IProcessQuery QueryProcessor { get { return TinyIoCContainer.Current.Resolve<IProcessQuery>(); } }

        //Todo: Temporary
        public static Argentum Initialize()
        {
            var callingAssembly = Assembly.GetCallingAssembly();

            TinyIoCContainer.Current.Register<IProcessCommand, DefaultCommandProcessor>();
            TinyIoCContainer.Current.Register<IProcessQuery, DefaultQueryProcessor>();


            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(callingAssembly, typeof(IHandleCommand<>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleQuery<,>));

            return new Argentum();
        }
    }
}