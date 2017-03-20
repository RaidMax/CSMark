using CSMarkCalculationTool;
using System;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v1.0.0.0";
            Benchmark bench = new Benchmark();

            Console.WriteLine("Running pythagoras benchmark...");

            bench.startBenchmark();

           Console.WriteLine("                                                                             ");

           Console.WriteLine("Single Core Score: " + bench);
 

            Console.WriteLine("                                                                             ");

            Console.WriteLine("Single Core Calculations per second: " + bench.returnSingleScoreCalc());

          

            Console.ReadLine();

        }
    }
}
