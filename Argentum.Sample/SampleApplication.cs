using System;
using System.Diagnostics;
using Argentum.Core;
using Argentum.Sample.Commands;
using Argentum.Sample.Queries;

namespace Argentum.Sample
{
    public class SampleApplication
    {
        private readonly IArgentum _app;

        public SampleApplication(IArgentum app)
        {
            _app = app;
        }

        public void DoSomething()
        {
            _app.Process(new PublishMessage("Hello Argentum!"));

            var dateTime = _app.Process(new GetCurrentDate());

            Console.WriteLine("This is what I got: {0}!", dateTime);

            Console.ReadLine();
        }

        public void TestThruput(int numberOfCommands)
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfCommands; i++)
            {
                _app.Process(new RunPerformance());
            }

            stopwatch.Stop();
            Console.WriteLine("{0} of commands took {1}", numberOfCommands, stopwatch.Elapsed);
        }
    }
}