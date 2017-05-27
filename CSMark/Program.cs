using System;
namespace CSMark{
    public class Program{
        public static void Main(string[] args){
            Console.Title = "CSMark v0.6.0.0";
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to CSMark...");
            string newCommand;
            while (true){
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To run the stress test utility, please enter STRESS-COUNTER.");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    //Single threaded CPU benchmarks
                    Console.WriteLine("Starting benchmark...");
                    bench.startBenchmark();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                    Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                    Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                else if (newCommand == "stress-counter")
                {
                    Console.WriteLine("Starting stress test with calculation counter...");
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(true);
                    newCommand = Console.ReadLine();
                    if(newCommand == "break")
                    {
                        stress.stopStressTest(false);
                    }
                    continue;
                }
                else if (newCommand == "stress")
                {
                    Console.WriteLine("Starting stress test...");
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(false);
                    newCommand = Console.ReadLine();
                    if (newCommand == "break")
                    {
                        stress.stopStressTest(false);
                    }
                    continue;
                }
                else if(newCommand == "clear")
                {
                    Console.Clear();
                    continue;
                }
            }          
        }
    }
}
