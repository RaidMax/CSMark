using System;
using System.Diagnostics;

namespace CSMark {
    public class Program {
        public static void Main(string[] args) {
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.13.0";
            Console.Write("Welcome to");
           Console.WriteLine(" CSMark.");
            double maxIterations = 0.05 * 1000.0 * 1000 * 1000;
            string benchAccuracy = "1";
            string newCommand;
            bool accuracyConfigured = false;
            Stopwatch time = new Stopwatch();

            while (true) {
                time.Reset();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                Console.Write("To run the single threaded and multi threaded tests, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("To run the single threaded tests only, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH-SINGLE.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("To run the multi threaded tests only, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH-MULTI.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("To run the stress test utility, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("STRESS.");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback or report any bugs by opening a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                Console.ForegroundColor = ConsoleColor.Gray;
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench" || newCommand == "bench-single" || newCommand == "bench-multi") {
                    Console.WriteLine("Would you like to configure the accuracy level of this benchmark?");
                    Console.WriteLine("ENTER Y or N");
                    string configure = Console.ReadLine();

                    if (configure.ToLower() == "y") {
                        Console.WriteLine("Welcome to the accuracy configurator.");
                        Console.WriteLine("Choosing a higher accuracy will result in substantially longer benchmarking times.");
                        Console.WriteLine("Accuracy level options: M1-M4, P1-P4, & W1-W7");
                        Console.WriteLine("Please ENTER the accuracy level you would like to use for the benchmark test.");
                        benchAccuracy = Console.ReadLine().ToUpper();

                        if (benchAccuracy == "M1") {
                            maxIterations = 0.05 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "M2") {
                            maxIterations = 0.1 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "M3") {
                            maxIterations = 0.2 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "M4") {
                            maxIterations = 0.5 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P1") {
                            maxIterations = 1.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P2") {
                            maxIterations = 2.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P3") {
                            maxIterations = 4.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P4") {
                            maxIterations = 8.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W1") {
                            maxIterations = 16.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W2") {
                            maxIterations = 32.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W3") {
                            maxIterations = 64.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W4") {
                            maxIterations = 128.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W5") {
                            maxIterations = 256.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W6") {
                            maxIterations = 384.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W7") {
                            maxIterations = 512.0 * 1000.0 * 1000 * 1000;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That's an invalid accuracy level. Please try again later.");
                            continue;
                        }
                        Console.WriteLine("You have selected Accuracy Level " + benchAccuracy);
                        accuracyConfigured = true;
                    }
                    string averages = "";
                    if (newCommand == "bench-single" || newCommand == "bench-multi")
                    {
                        //Do nothing for now as we don't support this.
                    }
                    else {
                        Console.WriteLine("Would you like the benchmark to run several times and give averaged results?");
                        Console.WriteLine("Please ENTER Y or N.");
                        averages = Console.ReadLine();
                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");

                    if (averages == "y") {
                        time.Start();

                        if (newCommand == "bench") {
                            bench.startBenchmark_Average(maxIterations);
                        }
                        time.Stop();
                    }
                    //If the user doesn't want averaged results or pressed the wrong key by accident, just run the normal benchmark.
                    else if (averages == "n" || averages != "y" && averages != "n") {
                        time.Start();

                        /*                           string cancelString = Console.ReadLine();

                        if (cancelString == "cancel" || cancelString == "break")
                        {
                            bench.cancelBenchmark(maxIterations, true);
                        }
*/
                        if (newCommand == "bench") {
                            bench.startBenchmark_Single(maxIterations, false);
                            bench.startBenchmark_Multi(maxIterations, false);
                        }
                        else if (newCommand == "bench-single") {
                            bench.startBenchmark_Single(maxIterations, false);
                        }
                        else if (newCommand == "bench-multi") {
                            bench.startBenchmark_Multi(maxIterations, false);
                        }

                        time.Stop();
                    }
       
                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (newCommand == "bench-mutli"){
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Multi Threaded Score: " + bench.returnMultiThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }
                    else if(newCommand == "bench-single"){
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }
                    else{
                        Console.WriteLine("                                                            ");
                        Console.WriteLine("Results:");

                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Multi Threaded Score: " + bench.returnMultiThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Benchmark scaling
                        Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                        Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                        Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                        Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
                        Console.WriteLine("ArithmeticSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "%");
                        Console.WriteLine("FizzBuzz Test Improvement: " + bench.returnScalingFizzBuzz().ToString() + "%");
                        Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }
                    
                    Console.WriteLine("Benchmark Accuracy: " + benchAccuracy); ;
                    Console.WriteLine("Configured Accuracy: " + accuracyConfigured);

                    if(accuracyConfigured == true){
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                    }
                    else if (accuracyConfigured == false){
                            Console.WriteLine("Time taken to run benchmark: " + ((time.ElapsedMilliseconds / 1000) / 5) + " Seconds");
                        }
                    else{
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