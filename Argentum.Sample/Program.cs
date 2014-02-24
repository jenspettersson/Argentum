using Argentum.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Argentum.Sample
{
    class Program
    {
        static void Main()
        {
            var container = new WindsorContainer();

            var argentum = Core.Argentum.Initialize();

            container.Register(Component.For<IArgentum>().Instance(argentum).LifestyleSingleton());
            container.Register(Component.For<SampleApplication>());

            var sampleApplication = container.Resolve<SampleApplication>();

            sampleApplication.DoSomething();
        }
    }
}
