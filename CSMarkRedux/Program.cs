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
using CSMarkLib;
using CSMarkLib.BenchmarkManagement;
using System;
namespace CSMarkRedux{
    class Program{
        static void Main(string[] args){
            Information info = new Information();
            Console.Title = "CSMark " + info.returnCSMarkVersionString();
            string CSMarkVersion = info.returnCSMarkVersionString() + "_PreRelease";
            CommandProcessor commandProcessor = new CommandProcessor();
            info.showLicenseInfo();
            info.checkForUpdate();
            ProjectInformation projInfo = new ProjectInformation();
            projInfo.getProjInfo();

            Console.WriteLine("Welcome to CSMark.");
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
                    Console.WriteLine("BENCH or 0");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the single threaded tests only, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("BENCH_SINGLE or 1");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the multi threaded tests only, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("BENCH_MULTI or 2");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the stress test utility, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("STRESS_TEST or 3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the stress test utility for a set amount of time, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("STRESS_TIMED or 4");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the Extreme benchmark (Experimental) enter the benchmark command followed by");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" --extreme");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To ensure results are saved after running the benchmark you can enter");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" --save");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback, or report bugs by opening a GitHub issue at https://github.com/CSMarkBenchmark/CSMark/issues/new ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    newCommand = Console.ReadLine().ToLower();

                    if (newCommand == "stress" || newCommand == "stress_test" || newCommand == "3"){
                        Console.WriteLine("To terminate the stress test enter BREAK or STOP.");
                       commandProcessor.startStressTest();
                        Console.WriteLine("Starting stress test.");
                        Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                        newCommand = Console.ReadLine();
                        if (newCommand == "break" || newCommand == "stop"){
                          commandProcessor.stopStressTest();
                        }
                        else{
                           commandProcessor.stopStressTest();
                        }
                        continue;
                    }
                    else if (newCommand == "stress_timed" || newCommand == "timed_stress" || newCommand == "timed-stress" || newCommand == "stress_test_timed" || newCommand == "timed_stress_test" || newCommand == "4"){
                        Console.WriteLine("Select the time format in SECONDS, MINUTES or HOURS.");
                        timedStress = Console.ReadLine().ToLower();
                        Console.WriteLine("How many " + timedStress + " would you like the stress test to run for?");
                        stressTime = Console.ReadLine().ToLower();
                        Console.WriteLine("Are you sure you want to run the stress test for " + stressTime + " " + timedStress + "?");
                        Console.WriteLine("Please enter Y or N");
                        stressConfirm = Console.ReadLine();

                        if (stressConfirm == "y"){
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
                    else if (newCommand.Contains("bench") || newCommand == "0" || newCommand == "1" || newCommand == "2"){
                        Console.WriteLine("Please enter an accuracy level.");
                        Console.WriteLine("Accepted Accuracy Levels are MX1-MX2, P1-P4 and W1-W7");
                        benchAccuracy = Console.ReadLine().ToUpper();
                       commandProcessor.setMaxIterations(benchAccuracy);

                        if (newCommand.Contains("bench_single") || newCommand == "1"){
                            commandProcessor.startBenchmarkNormal_Single();
                        commandProcessor.showNormalResultsConsole(true,false);
                         }
                        else if (newCommand.Contains("bench_multi") || newCommand == "bench-multi" || newCommand == "2"){
                            commandProcessor.startBenchmarkNormal_Multi();
                        commandProcessor.showNormalResultsConsole(false, true);
                         }
                        else if (newCommand.Contains("bench") || newCommand == "0"){
                            commandProcessor.startBenchmarkNormal();
                        commandProcessor.showNormalResultsConsole(true, true);
                        }
                        else if(newCommand.Contains("bench --extreme")){
                        commandProcessor.startBenchmarkExtreme();
                        commandProcessor.showExtremeResultsConsole(true, true);
                       }
                    else if (newCommand.Contains("bench_single --extreme")){
                        commandProcessor.startBenchmarkExtreme_Single();
                        commandProcessor.showExtremeResultsConsole(true, false);
                    }
                    else if (newCommand.Contains("bench_multi --extreme")){
                        commandProcessor.startBenchmarkExtreme_Multi();
                        commandProcessor.showExtremeResultsConsole(false, true);
                    }
                    else{
                           commandProcessor.setMaxIterations(0.2 * 1000 * 1000);
                            commandProcessor.startBenchmarkNormal();
                        commandProcessor.showNormalResultsConsole(true, true);
                        }
                    if (newCommand.Contains("--save")){
                        commandProcessor.handleSaveDialog("y", CSMarkVersion);
                    }
                    else{
                        Console.WriteLine("                                                ");
                        Console.WriteLine("Would you like to save the results to a Text File?");
                        Console.WriteLine("Please enter Y or N.");
                        string save = Console.ReadLine().ToLower();
                        commandProcessor.handleSaveDialog(save, CSMarkVersion);
                        continue;
                        }              
                    }
                    else if (newCommand == "exit"){
                        break;
                    }
                    else if(newCommand == "about" || newCommand == "version" || newCommand == "info" || newCommand == "-v"){
                    Console.WriteLine("                                     ");
                    Console.WriteLine("                                     ");
                    Console.WriteLine("CSMark Version: " + info.returnCSMarkVersionString());
                    Console.WriteLine("CSMarkLib Version: " + new AboutLib().returnCSMarkLibVersionString());
                    Console.WriteLine("AutoUpdaterNetStandard Version: " + new AutoUpdaterNetStandard.AboutLib().returnVersionString());
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