using System;
namespace CSMark{
    public class Program{
        public static void Main(string[] args){
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            bool extended;
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.8.0.0";
            Console.WriteLine("Welcome to CSMark 0.8.0.0");
            string newCommand;

            while (true){
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
                Console.WriteLine("To run the extended benchmark test utility, please enter BENCH-EXTENDED.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench" || newCommand == "bench-extended"){
                    if (newCommand == "bench"){
                        extended = false;
                    }
                    else{
                        extended = true; }
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark...");
                    bench.startBenchmark(false);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                                                                             ");
                    if (extended == false){
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError());
                    }
                    else if(extended == true){
                        Console.WriteLine("Pythagoras Extended Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                        Console.WriteLine("Trigonometry Extended Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                        Console.WriteLine("PercentageError Extended Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras ExtendedTest Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                        Console.WriteLine("Trigonometry Extended Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                        Console.WriteLine("PercentageError Extended Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError());
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (newCommand == "stress"){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Starting stress test.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(false);
                    newCommand = Console.ReadLine();
                    if (newCommand == "break"){
                        stress.stopStressTest(false);
                    }
                    continue;
                }
                else if (newCommand == "clear"){
                    Console.Clear();
                    continue;
                }
            }          
        }
    }
}