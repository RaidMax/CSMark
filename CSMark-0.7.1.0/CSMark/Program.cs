using System;
namespace CSMark{
    public class Program{
        public static void Main(string[] args){
            Console.Title = "CSMark v0.7.0.0";
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome to CSMark 0.7.1.0 - July 2017 Critical Bug Fix Update");
            string newCommand;
            while (true){
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
                Console.WriteLine("To run the extended benchmark test utility, please enter BENCH-EXTENDED.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To run the stress test utility with a live feed of the calculations being complete, please enter STRESS-COUNTER.");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    //Single threaded CPU benchmarks
                    Console.WriteLine("Starting benchmark...");
                    bench.startBenchmark(false);
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
                else if (newCommand == "bench-extended"){
                    //Single threaded CPU benchmarks
                    Console.WriteLine("Starting extended benchmark...");
                    bench.startBenchmark(false);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                                                                             ");
                    Console.WriteLine("Pythagoras Extended Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                    Console.WriteLine("Trigonometry Extended Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                    Console.WriteLine("PercentageError Extended Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras ExtendedTest Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                    Console.WriteLine("Trigonometry Extended Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                    Console.WriteLine("PercentageError Extended Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                else if (newCommand == "stress-counter" || newCommand == "stress"){
                    Console.WriteLine("Starting stress test with calculation counter...");
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    
                    if(newCommand == "stress")
                    {
                        stress.startStressTest(false);
                    }
                    else
                    {
                        stress.startStressTest(true);
                    }

                    newCommand = Console.ReadLine();
                    if(newCommand == "break")
                    {
                        stress.stopStressTest(false);
                    }
                    continue;
                }
                else if(newCommand == "clear"){
                    Console.Clear();
                    continue;
                }
            }          
        }
    }
}