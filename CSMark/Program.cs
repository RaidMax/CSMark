using CSMarkCalculationTool;
using System;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v1.0.0.0";
            BenchPythagoras bench = new BenchPythagoras();

            Console.WriteLine("Running pythagoras benchmark...");

            bench.singleThreadedBench();

           Console.WriteLine("                                                                             ");

           Console.WriteLine("Single Core Score: " + bench.returnSingleScore());
 

            Console.WriteLine("                                                                             ");

            Console.WriteLine("Single Core Calculations per second: " + bench.returnSingleScoreCalc());

          

            Console.ReadLine();

        }
    }
}
