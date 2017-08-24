using System;

namespace CSMarkRedux
{
    class Program
    {
        static void Main(string[] args)
        {
            //This checks for updates.
            AutoUpdaterNetStandard.AutoUpdater.Start("https://raw.githubusercontent.com/CSMarkBenchmark/CSMark/master/checkForUpdate.xml");

            /*
            if()
            {
            //Download the update
            AutoUpdaterNetStandard.AutoUpdater.DownloadUpdate();
            }
            */

            Console.Title = "CSMark 0.14.0";
            string CSMarkVersion = "0.14.0_PreRelease";

            conf.doesConfigurationExist();
            if (conf.doesConfigurationExist() == true)
            {
                //Proceed to CSMark
            }
            else if (conf.doesConfigurationExist() == false)
            {
                Console.WriteLine("Performing First Time Setup.");
                conf.createConfiguration(CSMarkVersion);

                Console.WriteLine("Welcome to CSMark.");
                Console.WriteLine("The current time is " + DateTime.Now.ToString());
                mgnt.startManagement(CSMarkVersion);
                Console.WriteLine("To check for updates, go to https://www.github.com/CSMarkBenchmark/CSMark/releases/");
                Console.WriteLine("For Support Status, go to https://github.com/CSMarkBenchmark/CSMark/blob/master/Support.md");
                string benchAccuracy = "MX2";
                string newCommand;
                string timedStress;
                string stressTime;
                string stressConfirm;
                while (true){
                    mgnt.managementChecks();

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
                    Console.Write("To run the stress test utility for a set amount of time, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("STRESS_TIMED.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Please give feedback, or report bugs by opening a GitHub issue at https://github.com/AluminiumTech/CSMark/issues/new ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    newCommand = Console.ReadLine().ToLower();

                    if (newCommand == "stress" || newCommand == "stress_test")
                    {
                        Console.WriteLine("To terminate the stress test enter BREAK or STOP.");
                        commandProcessor.startStressTest();
                        Console.WriteLine("Starting stress test.");
                        Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                        newCommand = Console.ReadLine();
                        if (newCommand == "break" || newCommand == "stop")
                        {
                            commandProcessor.stopStressTest();
                        }
                        else
                        {
                            commandProcessor.stopStressTest();
                        }
                        continue;
                    }
                    else if (newCommand == "stress_timed" || newCommand == "timed_stress" || newCommand == "timed-stress" || newCommand == "stress_test_timed" || newCommand == "timed_stress_test")
                    {
                        Console.WriteLine("Select the time format in SECONDS, MINUTES or HOURS.");
                        timedStress = Console.ReadLine().ToLower();

                        Console.WriteLine("How many " + timedStress + " would you like the stress test to run for?");
                        stressTime = Console.ReadLine().ToLower();

                        Console.WriteLine("Are you sure you want to run the stress test for " + stressTime + " " + timedStress + "?");
                        Console.WriteLine("Please enter Y or N");
                        stressConfirm = Console.ReadLine();

                        if (stressConfirm == "y")
                        {
                            if (timedStress == "seconds")
                            {
                                commandProcessor.startStressTest_Seconds(Double.Parse(stressTime));
                            }
                            else if (timedStress == "minutes")
                            {
                                commandProcessor.startStressTest_Minutes(Double.Parse(stressTime));
                            }
                            else if (timedStress == "hours")
                            {
                                commandProcessor.startStressTest_Hours(Double.Parse(stressTime));
                            }
                        }
                        continue;
                    }
                    else if (newCommand.Contains("bench"))
                    {
                        Console.WriteLine("Please enter an accuracy level.");
                        Console.WriteLine("Accepted Accuracy Levels are MX1-MX2, P1-P4 and W1-W7");
                        benchAccuracy = Console.ReadLine().ToUpper();

                        commandProcessor.setMaxIterations(benchAccuracy);

                        if (newCommand == "bench_single")
                        {
                            commandProcessor.startBenchmark_Single();
                            commandProcessor.showResults(true, false);
                        }
                        else if (newCommand == "bench_multi" || newCommand == "bench-multi")
                        {
                            commandProcessor.startBenchmark_Multi();
                            commandProcessor.showResults(false, true);
                        }
                        else if (newCommand == "bench")
                        {
                            commandProcessor.startBenchmark();
                            commandProcessor.showResults(true, true);
                        }
                        else
                        {
                            commandProcessor.setMaxIterations(0.2 * 1000 * 1000);
                            commandProcessor.startBenchmark();
                            commandProcessor.showResults(true, true);
                        }

                        Console.WriteLine("                                                ");
                        Console.WriteLine("Would you like to save the results to a Text File?");
                        Console.WriteLine("Please enter Y or N.");
                        string save = Console.ReadLine().ToLower();
                        commandProcessor.handleSaveDialog(save, CSMarkVersion);

                        continue;
                    }
                    else if (newCommand == "exit")
                    {
                        break;
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