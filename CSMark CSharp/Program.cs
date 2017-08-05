using System;
using System.Diagnostics;

namespace CSMark {
    public class Program {
        public static void Main(string[] args) {
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.12.0";
            Console.WriteLine("Welcome to CSMark.");
            double maxIterations = 1.0 * 1000.0 * 1000 * 1000;
            string benchAccuracy = "1"; //Benchmark Accuracy 1 = 1 Billion Calcs, 2 = 2 Billion Calcs, 3 = 4 Billion Calcs, 4 = 10 Billion Calcs
            string newCommand;
            bool accuracyConfigured = false;
            Stopwatch time = new Stopwatch();

            while (true) {
                time.Reset();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                Console.WriteLine("To run the single threaded and multi threaded tests, please ENTER BENCH.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To give feedback on CSMark or report any bugs/problems,");
                Console.WriteLine("please open a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    Console.WriteLine("Would you like to configure the accuracy level of this benchmark?");
                    Console.WriteLine("ENTER Y or N");
                    string configure = Console.ReadLine();
                    if (configure.ToLower() == "y")
                    {
                        Console.WriteLine("Welcome to the accuracy configurator.");
                        Console.WriteLine("Choosing a higher accuracy will result in substantially longer benchmarking times.");
                        Console.WriteLine("Accuracy level options: 1-7");
                        Console.WriteLine("Please ENTER the accuracy level you would like to use for the benchmark test.");
                        benchAccuracy = Console.ReadLine();

                        if (benchAccuracy == "1")
                        {
                            maxIterations = 1.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "2")
                        {
                            maxIterations = 2.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "3")
                        {
                            maxIterations = 4.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "4")
                        {
                            maxIterations = 8.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "5")
                        {
                            maxIterations = 16.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "6")
                        {
                            maxIterations = 32.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "7")
                        {
                            maxIterations = 64.0 * 1000.0 * 1000 * 1000;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That's an invalid accuracy level. Please try again later.");
                            continue;
                        }

                        Console.WriteLine("You have selected Accuracy Level " + benchAccuracy);
                        accuracyConfigured = true;
                    }

                    Console.WriteLine("Would you like the benchmark to run several times and give averaged results?");
                    Console.WriteLine("Please ENTER Y or N.");

                    string averages = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");

                    if (averages == "y"){
                        time.Start();
                        bench.startBenchmark_Average(maxIterations);
                        time.Stop();
                    }
                    //If the user doesn't want averaged results or pressed the wrong key by accident, just run the normal benchmark.
                    else if(averages == "n" || averages != "y" && averages != "n")
                    {
                        time.Start();
                        bench.startBenchmark_Single(maxIterations);
                        bench.startBenchmark_Multi(maxIterations);
                        time.Stop();
                    }
       
                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                    Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                    Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmarks
                    Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Millisecond");
                    Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Millisecond");
                    Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Millisecond");
                    Console.WriteLine("ArithmeticSumN Test Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Millisecond");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Benchmark scaling
                    Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                    Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                    Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                    Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
                    Console.WriteLine("ArithmeticSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "%");
                    Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Benchmark Accuracy: " + benchAccuracy); ;
                    Console.WriteLine("Configured Accuracy: " + accuracyConfigured);

                    if(accuracyConfigured == true){
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                    }
                    else if (accuracyConfigured == false)
                        {
                            Console.WriteLine("Time taken to run benchmark: " + ((time.ElapsedMilliseconds / 1000) / 5) + " Seconds");
                        }
                    else
                    {
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                    }
                    
                    continue;
                }
                else if (newCommand == "stress" || newCommand == "stress test" || newCommand == "stress-test") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting stress test.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                    stress.startStressTest();
                    newCommand = Console.ReadLine();
                    if (newCommand == "break" || newCommand == "stop") {
                        stress.stopStressTest(false);
                    }
                    continue;
                }          
                else if (newCommand == "clear" || newCommand == "restart" || newCommand == "clean") {
                    Console.Clear();
                    continue;
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a command supported by CSMark! Please enter a supported command correctly.");
                    continue;
                }
            }
        }
    }
}