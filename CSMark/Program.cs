using CSMarkCalculationTool;
using System;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v1.1.0.0";
            Benchmark bench = new Benchmark();
            Console.WriteLine("Running benchmarks...");

            bench.startBenchmark();

           Console.WriteLine("                                                                             ");
           Console.WriteLine("Single Threaded Score: " + bench.singleThreadedScore());
 
            Console.WriteLine("                                                                             ");
            Console.WriteLine("Single Threaded Calculations per second: " + bench.singleThreadedScorePerSecond());

/* 
            Console.WriteLine("                                                                             ");
            Console.WriteLine("Multi Threaded Score: " + bench.multiThreadedScore());

            Console.WriteLine("                                                                             ");
            Console.WriteLine("Multi Threaded Calculations per second: " + bench.multiThreadedScorePerSecond());
 */
            Console.ReadLine();

        }
    }
}
