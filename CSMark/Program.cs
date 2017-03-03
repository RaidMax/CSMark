using CSMarkCalculationTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v1.0.0.0";
            
            Console.WriteLine("Starting CSMark v1.0.0.0 ....");

            BenchPythagoras bench = new BenchPythagoras();

            Console.WriteLine("Running pythagoras benchmark...");

         bench.doPythagorasBenchmark();

           Console.WriteLine("Single Core Score: " + bench.returnSingleScore());
           Console.WriteLine("Multi Core Score: " + bench.returnMultiScore());

            Console.ReadLine();

        }
    }
}
