using CSMarkRedux.BenchmarkManagement;
using System;

namespace CSMarkRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandProcessor commandProcessor = new CommandProcessor();

            Console.Title = "CSMark Redux 0.14.0";
            string CSMarkVersion = "0.14.0_PreRelease";
            string CSMarkBranch = "1.0_PreRelease";

            Console.WriteLine("Welcome to CSMark.");
            Console.WriteLine("The current time is " + DateTime.Now.ToString());

            string benchAccuracy = "MX2";
            string newCommand;
            string timedStress;
           string stressTime;
            string stressConfirm;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                                                        ");
                Console.Write("To run the single threaded and multi threaded tests, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the single threaded tests only, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH_SINGLE.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the multi threaded tests only, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("BENCH_MULTI.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the stress test utility, please enter ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("STRESS_TEST.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback, or report bugs by opening a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                Console.ForegroundColor = ConsoleColor.Gray;
                newCommand = Console.ReadLine().ToLower();

                if(newCommand == "stress" || newCommand == "stress_test"){
                    Console.WriteLine("To terminate the stress test enter BREAK or STOP.");
                    
                }
                else if(newCommand == "stress_timed" || newCommand == "stress_test_timed" || newCommand == "timed_stress_test"){
                    Console.WriteLine("Select the time format in SECONDS, MINUTES or HOURS.");
                    timedStress = Console.ReadLine().ToLower();

                    Console.WriteLine("How many " + timedStress + " would you like the stress test to run for?");
                    stressTime = Console.ReadLine().ToLower();

                    Console.WriteLine("Are you sure you want to run the stress test for " + stressTime + " " + timedStress + "?");
                    Console.WriteLine("Please enter Y or N");
                    stressConfirm = Console.ReadLine();
                    
                    if(stressConfirm == "y"){
                        if (timedStress == "seconds"){
                            commandProcessor.startStressTest_Seconds(Double.Parse(stressTime));
                        }
                        else if (timedStress == "minutes"){
                            commandProcessor.startStressTest_Minutes(Double.Parse(stressTime));
                        }
                        else if (timedStress == "hours"){
                            commandProcessor.startStressTest_Hours(Double.Parse(stressTime));
                        }
                    }

                    continue;
                }
                else if (newCommand.Contains("bench"))
                {
                    benchAccuracy = Console.ReadLine().ToUpper();

                    if (newCommand == "bench_single"){
                        commandProcessor.startBenchmark_Single();
                    }
                    else if (newCommand == "bench_multi"){
                        commandProcessor.startBenchmark_Multi();
                    }
                    else if (newCommand == "bench_multi & tasks=true"){
                        commandProcessor.startBenchmark_Multi_Tasks();
                    }
                    else if(newCommand == "bench"){
                        commandProcessor.startBenchmark();
                    }

                    commandProcessor.showResults();
                }
                else if(newCommand == "exit"){
                    break;
                }
            }


        }
    }
}
