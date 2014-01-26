using System;
using System.Diagnostics;
using Argentum.Core.Tests;

namespace Argentum.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int timesToRun = 50000;
            
            Console.WriteLine("Running each test {0} times", timesToRun);

            var tests = new TemporaryTests();

            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine("Running DefaultQueryProcessorTests_Stubbing_Container");
            for (int i = 0; i < timesToRun; i++)
                tests.DefaultQueryProcessorTests_Stubbing_Container();
            
            Console.WriteLine("Took: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            Console.WriteLine("Running DefaultQueryProcessorTests_Not_Stubbing_Container");
            for (int i = 0; i < timesToRun; i++)
                tests.DefaultQueryProcessorTests_Not_Stubbing_Container();

            Console.WriteLine("Took: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            Console.WriteLine("Running DefaultQueryProcessorTests_No_Stubbing_At_all");
            for (int i = 0; i < timesToRun; i++)
                tests.DefaultQueryProcessorTests_No_Stubbing_At_all();

            Console.WriteLine("Took: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            Console.WriteLine("Running TinyIOCQueryProcessorTests_Not_Stubbing_Container");
            for (int i = 0; i < timesToRun; i++)
                tests.TinyIOCQueryProcessorTests_Not_Stubbing_Container();

            Console.WriteLine("Took: {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            Console.WriteLine("Running TinyIOCQueryProcessorTests_No_Stubbing_At_All");
            for (int i = 0; i < timesToRun; i++)
                tests.TinyIOCQueryProcessorTests_No_Stubbing_At_All();

            Console.WriteLine("Took: {0}\n", stopwatch.Elapsed);
            
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
