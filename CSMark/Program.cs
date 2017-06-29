﻿using System;
namespace CSMark{
    public class Program{
        public static void Main(string[] args){
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.9.0.0";
            Console.WriteLine("Welcome to CSMark 0.9.0.0");
            string newCommand;
          
            while (true){
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To give feedback on CSMark, please open a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new .");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark();
                    Console.WriteLine("                                                                             ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras());
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry());
                    Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError());
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras());
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry());
                    Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError());
                    ///Scaling stuff
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                    Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                    Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                    Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
                    Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                    continue;
                }
                else if (newCommand == "stress"){
                    Console.ForegroundColor = ConsoleColor.Green;
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
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a command supported by CSMark! Please try to enter a supported command correctly.");
                    continue;
                }
            }          
        }
    }
}