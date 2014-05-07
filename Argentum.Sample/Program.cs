using System.Reflection;
using Argentum.Core;
using Argentum.Sample.Commands;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TinyIoC;

namespace Argentum.Sample
{
    class Program
    {
        static void Main()
        {
            //var container = new WindsorContainer();

            //var argentum = Core.Argentum.Initialize();

            //container.Register(Component.For<IArgentum>().Instance(argentum).LifestyleSingleton());
            //container.Register(Component.For<SampleApplication>());

            //var sampleApplication = container.Resolve<SampleApplication>();

            //sampleApplication.DoSomething();


            var callingAssembly = Assembly.GetAssembly(typeof (Program));

            var registrator = new GenericRegistrator();
            registrator.RegisterFrom(callingAssembly, typeof(IHandleCommand<>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleQuery<,>));
            registrator.RegisterFrom(callingAssembly, typeof(IHandleEvent<>), allowMultipleImplementations: true);

            TinyIoCContainer.Current.Register<IProcessMessages, MessageProcessor>().AsSingleton();
            TinyIoCContainer.Current.Register<IBus, DirectBus>().AsSingleton();

            var bus = TinyIoCContainer.Current.Resolve<IBus>();

            bus.Publish(new PublishMessage("Testing with new bus"));
            bus.Commit();
        }
    }
}
