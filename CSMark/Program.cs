using System;
using System.Diagnostics;
using System.IO;

namespace CSMark {
    public class Program {
        public static void Main(string[] args) {
            BenchmarkController bench = new BenchmarkController();
            StressTestController stress = new StressTestController();
            Console.ForegroundColor = ConsoleColor.Gray;
       
            Console.Title = "CSMark 0.14.0";
            string CSMarkVersion = "0.14.0_PreRelease";
            Console.WriteLine("Welcome to CSMark.");
            Console.WriteLine("The current time is " + DateTime.Now.ToString());
            string newCommand;
            bool accuracyConfigured = false;
            Stopwatch time = new Stopwatch();
            double maxIterations = 0.2 * 1000.0 * 1000 * 1000;
            string benchAccuracy = "MX1";

            while (true) {
                    benchAccuracy = "MX1";
                    maxIterations = 0.2 * 1000.0 * 1000 * 1000;
                
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
                Console.Write("To run the stress test utility, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("STRESS.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback or report any bugs by opening a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                Console.ForegroundColor = ConsoleColor.Gray;
                newCommand = Console.ReadLine().ToLower();

                if (newCommand == "bench" || newCommand == "bench-single") {

                    if (newCommand == "bench-single" & Environment.ProcessorCount >= 8){
                        Console.WriteLine("Are you sure you want to test a highly multi-threaded CPU in the single threaded tests?");
                        Console.WriteLine("Enter Y or N.");
                        string decideSingle = Console.ReadLine();

                        if (decideSingle == "y"){
                            //Do nothing.
                        }
                        else{
                            Console.WriteLine("Quitting the single threaded benchmark.");
                            continue;
                        }
                    }

                    Console.WriteLine("Would you like to configure the accuracy level of this benchmark?");
                    Console.WriteLine("ENTER Y or N");
                    string configure = Console.ReadLine();

                    if (configure.ToLower() == "y") {
                        Console.WriteLine("Welcome to the accuracy configurator.");
                        Console.WriteLine("Choosing a higher accuracy will result in substantially longer benchmarking times.");

                            Console.WriteLine("Accuracy level options: MX1-MX2, P1-P4, & W1-W7");
                       
                       Console.WriteLine("Please ENTER the accuracy level you would like to use for the benchmark test.");
                        benchAccuracy = Console.ReadLine().ToUpper();

                        //Maintain some backwards compatible benchmark options for "Official Release" users. Insider Previews will use the newer accuracy levels

                        /*      if (benchAccuracy == "MX1" & Environment.ProcessorCount >= 4 || benchAccuracy == "MX2" & Environment.ProcessorCount >= 4){
                                  Console.WriteLine("Your CPU is probably too powerful for this accuracy level. Please try a different accuracy level.");
                                  continue;
                              } */
                        //  else
                        if (benchAccuracy == "MX1") {
                            maxIterations = 0.2 * 1000.0 * 1000 * 1000;
                        }
                        else if (benchAccuracy == "MX2") {
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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting benchmark test. The benchmark tests may take a while.");

                    time.Start();
                    if (newCommand == "bench") {
                        bench.startBenchmark_Single(maxIterations);
                        bench.startBenchmark_Multi(maxIterations);
                    }
                    else if (newCommand == "bench-single") {
                        bench.startBenchmark_Single(maxIterations);
                    }
                    time.Stop();

                    Console.WriteLine("                                                                             ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (newCommand == "bench-single") {
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("GeometricSumN Test Single Threaded Score: " + bench.returnSingleThreadedGeometricSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("Compound Interest Test Single Threaded Score: " + bench.returnSingleThreadedCompoundInterest() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }
                    else {
                        Console.WriteLine("                                                            ");
                        Console.WriteLine("Overall Score: ");
                        Console.WriteLine("Single Threaded Score :" + bench.singleOverallScore());
                        Console.WriteLine("Multi Threaded Score :" + bench.multiOverallScore());
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Score Breakdown:");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Pythagoras Test Single Threaded Score: " + bench.returnSingleThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Single Threaded Score: " + bench.returnSingleThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Single Threaded Score: " + bench.returnSingleThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Single Threaded Score: " + bench.returnSingleThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Single Threaded Score: " + bench.returnSingleThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("GeometricSumN Test Single Threaded Score: " + bench.returnSingleThreadedGeometricSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("Compound Interest Test Single Threaded Score: " + bench.returnSingleThreadedCompoundInterest() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Multi threaded CPU benchmarks
                        Console.WriteLine("Pythagoras Test Multi Threaded Score: " + bench.returnMultiThreadedPythagoras() + " Calculations Per Millisecond");
                        Console.WriteLine("Trigonometry Test Multi Threaded Score: " + bench.returnMultiThreadedTrigonometry() + " Calculations Per Millisecond");
                        Console.WriteLine("PercentageError Test Multi Threaded Score: " + bench.returnMultiThreadedPercentageError() + " Calculations Per Millisecond");
                        Console.WriteLine("ArithmeticSumN Test Multi Threaded Score: " + bench.returnMultiThreadedArithmeticSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("FizzBuzz Test Multi Threaded Score: " + bench.returnMultiThreadedFizzBuzz() + " Calculations Per Millisecond");
                        Console.WriteLine("GeometricSumN Test Multi Threaded Score: " + bench.returnMultiThreadedGeometricSumN() + " Calculations Per Millisecond");
                        Console.WriteLine("Compound Interest Test Multi Threaded Score: " + bench.returnMultiThreadedCompoundInterest() + " Calculations Per Millisecond");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        //Benchmark scaling
                        Console.WriteLine("Improvements compared to Single Threaded Performance: ");
                        Console.WriteLine("Pythagoras Test Improvement: " + bench.returnScalingPythagoras().ToString() + "%");
                        Console.WriteLine("Trigonometry Test Improvement: " + bench.returnScalingTrigonometry().ToString() + "%");
                        Console.WriteLine("PercentageError Test Improvement: " + bench.returnScalingPercentageError().ToString() + "%");
                        Console.WriteLine("ArithmeticSumN Test Improvement: " + bench.returnScalingArithmeticSumN().ToString() + "%");
                        Console.WriteLine("FizzBuzz Test Improvement: " + bench.returnScalingFizzBuzz().ToString() + "%");
                        Console.WriteLine("GeometricSumN Test Improvement: " + bench.returnScalingGeometricSumN().ToString() + "%");
                        Console.WriteLine("Compound Interest Test Improvement: " + bench.returnScalingCompoundInterest().ToString() + "%");
                        Console.WriteLine("CPU Thread count: " + Environment.ProcessorCount.ToString());
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    }

                    Console.WriteLine("Benchmark Accuracy: " + benchAccuracy); ;
                    Console.WriteLine("Configured Accuracy: " + accuracyConfigured);

                    if (accuracyConfigured == true) {
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                    }
                    else if (accuracyConfigured == false) {
                        Console.WriteLine("Time taken to run benchmark: " + ((time.ElapsedMilliseconds / 1000)) + " Seconds");
                    }
                    else {
                        Console.WriteLine("Time taken to run benchmark: " + (time.ElapsedMilliseconds / 1000) + " Seconds");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("                                                ");
                    Console.WriteLine("Would you like to save the results to a File?");
                    Console.WriteLine("Please enter Y or N.");
                    string saveConfirm = Console.ReadLine().ToLower();

                    if (saveConfirm == "y") {
                        var score = new ScoreSaver();
                        Console.WriteLine("The file will be created in CSMark's Current Directory in a folder called RESULTS.");
                        score.setArithmeticSumN(bench.returnSingleThreadedArithmeticSumN().ToString(), bench.returnMultiThreadedArithmeticSumN().ToString());
                        score.setFizzBuzz(bench.returnSingleThreadedFizzBuzz().ToString(), bench.returnMultiThreadedFizzBuzz().ToString());
                        score.setPythagoras(bench.returnSingleThreadedPythagoras().ToString(), bench.returnMultiThreadedPythagoras().ToString());
                        score.setTrigonometry(bench.returnSingleThreadedTrigonometry().ToString(), bench.returnMultiThreadedTrigonometry().ToString());
                        score.setPercentageError(bench.returnSingleThreadedPercentageError().ToString(), bench.returnMultiThreadedPercentageError().ToString());
                        score.setScaling(bench.returnScalingFizzBuzz().ToString(), bench.returnScalingPythagoras().ToString(), bench.returnScalingTrigonometry().ToString(), bench.returnScalingArithmeticSumN().ToString(), bench.returnScalingPercentageError().ToString(),bench.returnScalingGeometricSumN().ToString(),bench.returnScalingCompoundInterest().ToString());
                        score.saveToTextFile(Directory.GetCurrentDirectory() + "\\results", CSMarkVersion, benchAccuracy, accuracyConfigured);
                    }
                    else if (saveConfirm == "n" || saveConfirm != "y" & saveConfirm != "n") {
                        //Do nothing, the app will automatically continue and will restart the While Loop.
                    }
                    continue;
                }
                else if (newCommand == "stress" || newCommand == "stress test" || newCommand == "stress-test" || newCommand == "burn") {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting stress test.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                    stress.startStressTest();
                    newCommand = Console.ReadLine();
                    if (newCommand == "break" || newCommand == "stop") {
                        stress.stopStressTest(false);
                    }
                    else{
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