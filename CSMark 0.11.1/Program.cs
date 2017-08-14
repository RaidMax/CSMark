using System;
namespace CSMark {
    public class Program {
        public static void Main(string[] args) {
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "CSMark 0.11.1 - CSMark August 2017-002 Critical Security Update";
            Console.WriteLine("Welcome to CSMark 0.11.1");
            double maxIterations = 1000.0 * 1000 * 1000;
            string benchAccuracy = "1"; //Benchmark Accuracy 1 = 1 Billion Calcs, 2 = 2 Billion Calcs, 3 = 4 Billion Calcs, 4 = 9 Billion Calcs
            string newCommand;

            while (true) {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                Console.WriteLine("To run the single threaded and multi threaded tests, please enter BENCH.");
                Console.WriteLine("To run the single threaded and multi threaded tests multiple times to get an average, please enter BENCH-AVERAGE.");
                Console.WriteLine("To run the stress test utility, please enter STRESS.");
                Console.WriteLine("To give feedback on CSMark or report any bugs/problems, please open a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench"){
                    Console.WriteLine("Would you like to configure the accuracy level of this benchmark?");
                    Console.WriteLine("ENTER Y or N");
                    string configure = Console.ReadLine();
                    if (configure.ToLower() == "y")
                    {
                        Console.WriteLine("Welcome to the accuracy configurator.");
                        Console.WriteLine("Choosing a higher accuracy will result in substantially longer benchmarking times.");
                        Console.WriteLine("Accuracy level options: 1-4");
                        Console.WriteLine("Please ENTER the accuracy level you would like to use for the benchmark test.");
                    benchAccuracy = Console.ReadLine();
                    
                    if (benchAccuracy == "1"){
                        maxIterations = 1000.0 * 1000 * 1000;
                    }
                    else if (benchAccuracy == "2"){
                        maxIterations = 2000.0 * 1000 * 1000;
                    }
                    else if (benchAccuracy == "3"){
                        maxIterations = 4000.0 * 1000 * 1000;
                    }
                    else if (benchAccuracy == "4"){
                        maxIterations = 9000.0 * 1000 * 1000;
                    }
                    else{
                        maxIterations = 1000.0 * 1000 * 1000;
                    }
                    Console.WriteLine("You have selected Accuracy Level " + benchAccuracy);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                        bench.startBenchmark_Single(maxIterations);
                        bench.startBenchmark_Multi(maxIterations);
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
                        continue;

                    }
                    else if (configure.ToLower() == "n"){
                        //Start the benchmarks right away if the user doesn't want to configure the accuracy level
                        Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                        bench.startBenchmark_Single(maxIterations);
                        bench.startBenchmark_Multi(maxIterations);
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
                        continue;
                    }
                    else {
                    }        
                    continue;
                }
                else if (newCommand == "bench-average"){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting benchmark. The benchmark tests may take a while.");
                    bench.startBenchmark_Average(maxIterations);
                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                    Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                    Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                    Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    //Multi threaded CPU benchmark averages;
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
                    Console.WriteLine("Benchmark Accuracy: " + benchAccuracy);
                    continue;
                }
                else if (newCommand == "stress") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting stress test.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("To stop the stress test, please exit the program or enter BREAK");
                    stress.startStressTest(false);
                    newCommand = Console.ReadLine();
                    if (newCommand == "break") {
                        stress.stopStressTest(false);
                    }
                    else{
                        stress.stopStressTest(false);
                    }
                    continue;
                }          
                else if (newCommand == "clear") {
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