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
     //       bench.multiThreadedBench();

            Console.WriteLine("                                                                             ");

           Console.WriteLine("Single Core Score: " + bench.returnSingleScore());
        //   Console.WriteLine("Multi Core Score: " + bench.returnMultiScore());

            Console.WriteLine("                                                                             ");

            Console.WriteLine("Single Core Calculations per second: " + bench.returnSingleScoreCalc());
   //         Console.WriteLine("Multi Core Calculations per second: " + bench.returnMultiScoreCalc());

            Console.ReadLine();

        }
    }
}
