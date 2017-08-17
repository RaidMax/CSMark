using System;
using System.Diagnostics;
using System.IO;

namespace CSMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Title = "CSMark 0.14.0";
            string CSMarkVersion = "0.14.0_PreRelease";
            Console.WriteLine("Welcome to CSMark.");
            string newCommand;
            bool accuracyConfigured = false;
            Stopwatch time = new Stopwatch();
            double maxIterations = 0.2 * 1000.0 * 1000 * 1000;
            string benchAccuracy = "MX1";

            double singleScore = 0;
            double multiScore = 0;
            string singleOverall = "";
            string multiOverall = "";

            while (true)
            {
                benchAccuracy = "MX1";
                maxIterations = 0.2 * 1000.0 * 1000 * 1000;

                time.Reset();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                Console.Write("To run the single threaded and multi threaded tests, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the stress test utility, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("STRESS.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback or report any bugs by opening a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                Console.ForegroundColor = ConsoleColor.Gray;
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench" || newCommand == "bench-single")
                {
                    Console.WriteLine("Would you like to configure the accuracy level of this benchmark?");
                    Console.WriteLine("ENTER Y or N");
                    string configure = Console.ReadLine();

                    if (configure.ToLower() == "y")
                    {
                        Console.WriteLine("Welcome to the accuracy configurator.");
                        Console.WriteLine("Choosing a higher accuracy will result in substantially longer benchmarking times.");
                        Console.WriteLine("Accuracy level options: MX1-MX2, P1-P4, & W1-W7");
                        Console.WriteLine("Please ENTER the accuracy level you would like to use for the benchmark test.");
                        benchAccuracy = Console.ReadLine().ToUpper();

                        if (benchAccuracy == "MX1")
                        {
                            maxIterations = 0.2 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "MX2")
                        {
                            maxIterations = 0.5 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P1")
                        {
                            maxIterations = 1.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P2")
                        {
                            maxIterations = 2.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P3")
                        {
                            maxIterations = 4.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "P4")
                        {
                            maxIterations = 8.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W1")
                        {
                            maxIterations = 16.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W2")
                        {
                            maxIterations = 32.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W3")
                        {
                            maxIterations = 64.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W4")
                        {
                            maxIterations = 128.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W5")
                        {
                            maxIterations = 256.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W6")
                        {
                            maxIterations = 384.0 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "W7")
                        {
                            maxIterations = 512.0 * 1000.0 * 1000 * 1000;
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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting benchmark test. The benchmark tests may take a while.");

                    time.Start();
                    if (newCommand == "bench")
                    {
                        bench.startBenchmark_Single(maxIterations);
                        bench.startBenchmark_Multi(maxIterations);
                        time.Stop();

                        singleScore = bench.returnSingleThreadedArithmeticSumN() + bench.returnSingleThreadedCompoundInterest() + bench.returnSingleThreadedFizzBuzz() + bench.returnSingleThreadedGeometricSumN() + bench.returnSingleThreadedPercentageError() + bench.returnSingleThreadedPythagoras() + bench.returnSingleThreadedTrigonometry();
                        singleScore = singleScore / 7;

                  /*      if (singleScore.ToString().Length >= 4 & singleScore.ToString().Length < 7)
                        {
                            singleScore = singleScore / 1000.0;
                            singleOverall = singleScore.ToString() + " Thousand";
                        }
                        else if (singleScore.ToString().Length >= 7 & singleScore.ToString().Length < 10)
                        {
                            singleScore = singleScore / (1000.0 * 1000);
                            singleOverall = singleScore.ToString() + " Million";
                        }
                        else if (singleScore.ToString().Length >= 10 & singleScore.ToString().Length < 13)
                        {
                            singleScore = singleScore / (1000.0 * 1000 * 1000);
                            singleOverall = singleScore.ToString() + " Billion";
                        }
                        else if (singleScore.ToString().Length >= 13 & singleScore.ToString().Length < 16)
                        {
                            singleScore = singleScore / (1000.0 * 1000 * 1000 * 1000);
                            singleOverall = singleScore.ToString() + " Trillion";
                        }
                        else if (singleScore.ToString().Length >= 16 & singleScore.ToString().Length < 19)
                        {
                            singleScore = singleScore / (1000.0 * 1000 * 1000 * 1000 * 1000);
                            singleOverall = singleScore.ToString() + " Quadrillion";
                        }
                        */
                        singleOverall +=singleScore.ToString() + " CSMark SPX";

                        multiScore = bench.returnMultiThreadedArithmeticSumN() + bench.returnMultiThreadedCompoundInterest() + bench.returnMultiThreadedFizzBuzz() + bench.returnMultiThreadedGeometricSumN() + bench.returnMultiThreadedPercentageError() + bench.returnMultiThreadedPythagoras() + bench.returnMultiThreadedTrigonometry();
                        multiScore = multiScore / 7;

                  /*      if (multiScore.ToString().Length >= 4 & multiScore.ToString().Length < 7)
                        {
                            multiScore = multiScore / 1000.0;
                            multiOverall = multiScore.ToString() + " Thousand";
                        }
                        else if (multiScore.ToString().Length >= 7 & multiScore.ToString().Length < 10)
                        {
                            multiScore = multiScore / (1000.0 * 1000);
                            multiOverall = multiScore.ToString() + " Million";
                        }
                        else if (multiScore.ToString().Length >= 10 & multiScore.ToString().Length < 13)
                        {
                            multiScore = multiScore / (1000.0 * 1000 * 1000);
                            multiOverall = multiScore.ToString() + " Billion";
                        }
                        else if (multiScore.ToString().Length >= 13 & multiScore.ToString().Length < 16)
                        {
                            multiScore = multiScore / (1000.0 * 1000 * 1000 * 1000);
                            multiOverall = multiScore.ToString() + " Trillion";
                        }
                        else if (multiScore.ToString().Length >= 16 & multiScore.ToString().Length < 19)
                        {
                            multiScore = multiScore / (1000.0 * 1000 * 1000 * 1000 * 1000);
                            multiOverall = multiScore.ToString() + " Quadrillion";
                        }
                        */
                        multiOverall += multiScore.ToString() + " CSMark MPX";

                        Console.WriteLine("                                                                             ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("                                                            ");
                        Console.WriteLine("Overall Score: ");
                        Console.WriteLine("Single Threaded Score: " + singleOverall);
                        Console.WriteLine("Multi Threaded Score: " + multiOverall);
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.WriteLine("Score Breakdown:");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Second");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Second");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Second");
                        Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Second");
                        Console.WriteLine("FizzBuzz Test Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Second");
                        Console.WriteLine("GeometricSumN Test Single Threaded Score: " + bench.returnSingleThreadedGeometricSumN() + " Calculations Per Second");
                        Console.WriteLine("Compound Interest Test Single Threaded Score: " + bench.returnSingleThreadedCompoundInterest() + " Calculations Per Second");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Second");
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Second");
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Second");
                        Console.WriteLine("ArithmeticSumN Test Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Second");
                        Console.WriteLine("FizzBuzz Test Multi Threaded Score: " + bench.returnMultiThreadedFizzBuzz() + " Calculations Per Second");
                        Console.WriteLine("GeometricSumN Test Multi Threaded Score: " + bench.returnMultiThreadedGeometricSumN() + " Calculations Per Second");
                        Console.WriteLine("Compound Interest Test Multi Threaded Score: " + bench.returnMultiThreadedCompoundInterest() + " Calculations Per Second");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Benchmark scaling
                        Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                        Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "x");
                        Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "x");
                        Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "x");
                        Console.WriteLine("ArithmeticSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "x");
                        Console.WriteLine("FizzBuzz Test Improvement: " + bench.returnScalingFizzBuzz().ToString() + "x");
                        Console.WriteLine("GeometricSumN Test Improvement: " + bench.returnScalingGeometricSumN().ToString() + "x");
                        Console.WriteLine("Compound Interest Test Improvement: " + bench.returnScalingCompoundInterest().ToString() + "x");
                        Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Benchmark Accuracy: " + benchAccuracy); ;
                        Console.WriteLine("Configured Accuracy: " + accuracyConfigured);
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("                                                ");
                        Console.WriteLine("Would you like to save the results to a File?");
                        Console.WriteLine("Please enter Y or N.");
                        string saveConfirm = Console.ReadLine().ToLower();

                        if (saveConfirm == "y")
                        {
                            var score = new ScoreSaver();
                            Console.WriteLine("The file will be created in CSMark's Current Directory in a folder called RESULTS.");
                            score.setArithmeticSumN(bench.returnSingleThreadedArithmeticSumN().ToString(), bench.returnMultiThreadedArithmeticSumN().ToString());
                            score.setFizzBuzz(bench.returnSingleThreadedFizzBuzz().ToString(), bench.returnMultiThreadedFizzBuzz().ToString());
                            score.setPythagoras(bench.returnSingleThreadedPythagoras().ToString(), bench.returnMultiThreadedPythagoras().ToString());
                            score.setTrigonometry(bench.returnSingleThreadedTrigonometry().ToString(), bench.returnMultiThreadedTrigonometry().ToString());
                            score.setPercentageError(bench.returnSingleThreadedPercentageError().ToString(), bench.returnMultiThreadedPercentageError().ToString());
                            score.setScaling(bench.returnScalingFizzBuzz().ToString(), bench.returnScalingPythagoras().ToString(), bench.returnScalingTrigonometry().ToString(), bench.returnScalingArithmeticSumN().ToString(), bench.returnScalingPercentageError().ToString(), bench.returnScalingGeometricSumN().ToString(), bench.returnScalingCompoundInterest().ToString());
                            score.saveToTextFile(Directory.GetCurrentDirectory() + "\\results", CSMarkVersion, benchAccuracy, accuracyConfigured);
                        }
                        else if (saveConfirm == "n" || saveConfirm != "y" & saveConfirm != "n")
                        {
                            //Do nothing, the app will automatically continue and will restart the While Loop.
                        }
                        continue;
                    }
                    else if (newCommand == "stress" || newCommand == "stress test" || newCommand == "stress-test" || newCommand == "burn")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Starting stress test.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                        stress.startStressTest();
                        newCommand = Console.ReadLine();
                        if (newCommand == "break" || newCommand == "stop")
                        {
                            stress.stopStressTest(false);
                        }
                        else
                        {
                            stress.stopStressTest(false);
                        }
                        continue;
                    }
                    else if (newCommand == "clear" || newCommand == "restart" || newCommand == "clean")
                    {
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That's not a command supported by CSMark! Please enter a supported command correctly.");
                        continue;
                    }
                }
            }
        }
    }
}