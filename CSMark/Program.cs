using CSMarkCalculationTool;
using System;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v0.2.0.0";
            Benchmark bench = new Benchmark();
            Console.WriteLine("Running benchmarks...");

            bench.startBenchmark();

           Console.WriteLine("                                                                             ");
           Console.WriteLine("Single Threaded Score: " + bench.singleThreadedScore());
 
            Console.WriteLine("                                                                             ");
            Console.WriteLine("Single Threaded Calculations per second: " + bench.singleThreadedScorePerSecond());
            Console.ReadLine();

        }
    }
}
