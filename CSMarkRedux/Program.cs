/* CSMark
    Copyright (C) 2017  AluminiumTech

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Diagnostics;
using System.Reflection;

namespace CSMarkRedux
{
    class Program{
        static void Main(string[] args){
            Stopwatch checkUpdateTimer = new Stopwatch();
            Console.Title = "CSMark " + Assembly.GetEntryAssembly().GetName().Version.ToString();
            string CSMarkVersion = "0.15.0_PreRelease";

            //This checks for updates on startup
            checkUpdateTimer.Reset();
            checkUpdateTimer.Start();
            AutoUpdaterNetStandard.AutoUpdater.Start("https://raw.githubusercontent.com/CSMarkBenchmark/CSMark/master/checkForUpdate.xml");
            AutoUpdaterNetStandard.AutoUpdater autoUpdater = new AutoUpdaterNetStandard.AutoUpdater();

            Console.WriteLine("Checking for updates to CSMark. This should just take a moment.");
            //If it takes longer than 30 seconds to check for updates then stop and tell the user it couldn't check for updates.
            while(autoUpdater.checkForUpdateCompleted() == false && checkUpdateTimer.ElapsedMilliseconds <= (30.0 * 1000)){

            }
            if(autoUpdater.checkForUpdateCompleted() == false){
                Console.WriteLine("Checking for updates failed. Proceeding to start CSMark.");
            }
            else{
                Console.WriteLine("Took " + (checkUpdateTimer.ElapsedMilliseconds / 1000) + " seconds to check for updates.");
            }

            if(autoUpdater.currentVersion() == autoUpdater.installedVersion()){
                //Do nothing
            }
            else if(autoUpdater.currentVersion() != autoUpdater.installedVersion()){
                Console.WriteLine("A new update for CSMark is available!");
                Console.WriteLine("                                     ");
                Console.WriteLine("Latest CSMark Version: " + autoUpdater.currentVersion());
                Console.WriteLine("Intalled CSMark Version: " + autoUpdater.installedVersion());
                Console.WriteLine("The changelog for the latest version can be found here: " + autoUpdater.changeLogURL());
                Console.WriteLine("                                     ");
                Console.WriteLine("Would you like to download and install updates?");
                Console.WriteLine("Enter Y or N");
                string update = Console.ReadLine().ToLower();

                if(update == "y"){
                    Console.WriteLine("Downloading and Installing CSMark " + autoUpdater.currentVersion());
                    //Download and install the update
                    AutoUpdaterNetStandard.AutoUpdater.DownloadUpdate();
                }
                else if(update == "n"){
                    //Do nothing and continue to CSMark.
                    Console.WriteLine("                                     ");
                }
            }
                    
            Console.WriteLine("Welcome to CSMark.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Copyright (C) 2017 AluminiumTech");
            Console.WriteLine("This product is licensed under the GNU General Public License (GPL) v3 open source license.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("This is free software (As defined at https://www.gnu.org/philosophy/free-sw.html) :");
            Console.WriteLine("you can re-distribute it and/or modify it under the terms of the GNU General Public License as published by");
            Console.WriteLine("the Free Software Foundation.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("This program is distributed in the hope that it will be useful but WITHOUT ANY WARRANTY;");
            Console.WriteLine("without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.");
            Console.WriteLine("See the GNU General Public License for more details.");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("You should have received a copy of the GNU General Public License along with this program.");
            Console.WriteLine("If not, see http://www.gnu.org/licenses/");
            Console.WriteLine("To learn more about the GPL v3 license, go to http://www.gnu.org/licenses/");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("                                                                    ");
            Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("To check for updates, go to https://www.github.com/CSMarkBenchmark/CSMark/releases/");
                Console.WriteLine("For Support Status, go to https://github.com/CSMarkBenchmark/CSMark/blob/master/Support.md");
                string benchAccuracy = "MX2";
                string newCommand;
                string timedStress;
                string stressTime;
                string stressConfirm;

                while (true){
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
                      //  commandProcessor.startStressTest();
                        Console.WriteLine("Starting stress test.");
                        Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                        newCommand = Console.ReadLine();
                        if (newCommand == "break" || newCommand == "stop")
                        {
                          //  commandProcessor.stopStressTest();
                        }
                        else
                        {
                            //commandProcessor.stopStressTest();
                        }
                        continue;
                    }
                    else if (newCommand == "stress_timed" || newCommand == "timed_stress" || newCommand == "timed-stress" || newCommand == "stress_test_timed" || newCommand == "timed_stress_test"){
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
                          //      commandProcessor.startStressTest_Seconds(Double.Parse(stressTime));
                            }
                            else if (timedStress == "minutes")
                            {
                         //       commandProcessor.startStressTest_Minutes(Double.Parse(stressTime));
                            }
                            else if (timedStress == "hours")
                            {
                         //       commandProcessor.startStressTest_Hours(Double.Parse(stressTime));
                            }
                        }
                        continue;
                    }
                    else if (newCommand.Contains("bench")){
                        Console.WriteLine("Please enter an accuracy level.");
                        Console.WriteLine("Accepted Accuracy Levels are MX1-MX2, P1-P4 and W1-W7");
                        benchAccuracy = Console.ReadLine().ToUpper();

                    //    commandProcessor.setMaxIterations(benchAccuracy);

                        if (newCommand == "bench_single")
                        {
                       //     commandProcessor.startBenchmark_Single();
                     //       commandProcessor.showResults(true, false);
                        }
                        else if (newCommand == "bench_multi" || newCommand == "bench-multi")
                        {
                       //     commandProcessor.startBenchmark_Multi();
                        //    commandProcessor.showResults(false, true);
                        }
                        else if (newCommand == "bench")
                        {
                       //     commandProcessor.startBenchmark();
                       //     commandProcessor.showResults(true, true);
                        }
                        else
                        {
                       //     commandProcessor.setMaxIterations(0.2 * 1000 * 1000);
                        //    commandProcessor.startBenchmark();
                       //     commandProcessor.showResults(true, true);
                        }

                        Console.WriteLine("                                                ");
                        Console.WriteLine("Would you like to save the results to a Text File?");
                        Console.WriteLine("Please enter Y or N.");
                        string save = Console.ReadLine().ToLower();
                    //    commandProcessor.handleSaveDialog(save, CSMarkVersion);

                        continue;
                    }
                    else if (newCommand == "exit"){
                        break;
                    }
                    else if (newCommand == "clear" || newCommand == "restart" || newCommand == "clean"){
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