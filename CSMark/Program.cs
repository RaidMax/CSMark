﻿using System;
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
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the benchmark test utility, please enter BENCH.");
                Console.WriteLine("To run the extended benchmark test utility, please enter BENCH-EXTENDED.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To give feedback on CSMark, open a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new .");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench" || newCommand == "bench-extended"){
                    if (newCommand == "bench"){
                        extended = false;
                    }
                    else{
                        extended = true; }
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark(extended);
                    Console.WriteLine("                                                                             ");
                    if (extended == false){
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Benchmark Type: Standard Test.");
                    }
                    else if(extended == true){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Benchmark Type: Extended Test.");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Milliseconds");
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Milliseconds");
                    Console.WriteLine("Percentage Error Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Milliseconds");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Milliseconds");
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Milliseconds");
                    Console.WriteLine("Percentage Error Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Milliseconds");
                    ///Scaling stuff
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                    Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                    Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                    Console.WriteLine("Percentage Error Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
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