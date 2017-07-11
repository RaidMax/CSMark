﻿using System;
namespace CSMark{
    public class Program{
        public static void Main(string[] args){
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.10.0.0";
            Console.WriteLine("Welcome to CSMark 0.10.0.0");
            double maxIterations = 10.0 * 1000 * 1000;
            string newCommand = "";
          
            while (true){
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                             ");
                Console.WriteLine("To run the single threaded and multi threaded tests, please enter BENCH.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To give feedback on CSMark, please open a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                newCommand = "";
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark_Single(maxIterations);
                    bench.startBenchmark_Multi(maxIterations);
                    /*   if(bench.returnCheckZeroResult() == true){
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("BENCHMARKING ERROR: The benchmark tests you have attempted to run have failed to complete successfully.");
                           Console.WriteLine("Please try again after a system reboot. If the problem persists then please open a github issue in addition to uninstalling and re-installing the program.");
                           continue;
                       }
                       */
                    //   else if(bench.returnCheckZeroResult() == false){

                    Console.WriteLine("                                                                             ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Milliseconds");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Milliseconds");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Milliseconds");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Milliseconds");
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Milliseconds");
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Milliseconds");
                        ///Scaling stuff
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                        Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                        Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                        Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
                        Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                        continue;
                   // }

                   
                }
        /*        else if (newCommand == "bench-single")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark_Single();
                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Milliseconds");
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Milliseconds");
                    Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Milliseconds");
                    Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                    continue;
                }
                else if (newCommand == "bench-multi")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Single threaded CPU benchmarks         
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark_Multi();
                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Milliseconds");
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Milliseconds");
                    Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Milliseconds");
                    Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                    continue;
                }
                */
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