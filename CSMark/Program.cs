using System;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v0.3.0.0 - Insider Release";
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Welcome to CSMark...");
            Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
            Console.WriteLine("To run the stress test utility, please enter STRESS.");

           // string command;
            string newCommand;
            while (true)
            {
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench")
                {
                    Console.WriteLine("Starting benchmark...");
                    bench.startBenchmark();
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Single Threaded Score: " + bench.singleThreadedScore());
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Single Threaded Calculations per second: " + bench.singleThreadedScorePerSecond());

                    continue;
                }
                else if (newCommand == "stress")
                {
                    Console.WriteLine("Starting stress test...");
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(true);

                    string stop = Console.ReadLine().ToLower();

                    if (stop == "break")
                    {
                        stress.stopStressTest(false);
                    }

                    continue;
                }
            }

            

          
        }
    }
}
