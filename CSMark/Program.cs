using System;
namespace CSMark
{
    public class Program{
        public static void Main(string[] args)
        {
            Console.Title = "CSMark v0.4.0.0 - Insider Release";
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to CSMark...");
            Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
            Console.WriteLine("To run the stress test utility, please enter STRESS.");

            string newCommand;
            while (true){
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    //Single threaded CPU benchmarks
                    Console.WriteLine("Starting benchmark...");
                    bench.startBenchmark();
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Gradient Test Single Threaded Score: " + bench.returnSingleThreadedGradient());
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Gradient Test Multi Threaded Score: " + bench.returnMultiThreadedGradient());
                    continue;
                }
                else if (newCommand == "stress"){
                    Console.WriteLine("Starting stress test...");
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(true);
                    string stop = Console.ReadLine().ToLower();

                    if (stop == "break"){
                        stress.stopStressTest(false);
                    }
                    continue;
                }
            }          
        }
    }
}
