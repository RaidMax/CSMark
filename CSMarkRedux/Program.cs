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
    along with this program.  If not, see <http://www.gnu.org/licenses/>. */
using CSMarkLib;
using CSMarkLib.BenchmarkManagement;
using System;
using System.Runtime.InteropServices;
namespace CSMarkRedux{
    class Program{
        public static string benchCommand;
        public static string accuracyLevel;
        public static bool saveToFile;
        public static bool exitOnComplete = false;
        public static string threadsArg;

        static void Main(string[] args){       
            ///
            ///Accept command line arguments
            ///
            if(args.Length == 2){
                benchCommand = args[0];
                accuracyLevel = args[1];
            }
            else if(args.Length == 3){
                benchCommand = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
            }
            else if (args.Length == 4){
                benchCommand = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
                exitOnComplete = bool.Parse(args[3]);
            }
            else if (args.Length == 5){
                benchCommand = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
                exitOnComplete = bool.Parse(args[3]);
                threadsArg = args[4];
            }
            else{
                //Do nothing.
            }

        CSMarkPlatform csM = new CSMarkPlatform();
            Information info = new Information();
            Console.Title = "CSMark " + info.returnCSMarkVersionString() + " Community Edition";  
            string CSMarkVersion = info.returnCSMarkVersionString() + "_CommunityEdition";
            CommandProcessor commandProcessor = new CommandProcessor();
            info.showLicenseInfo();
            info.checkForUpdate();
            Console.WriteLine("Welcome to CSMark Community Edition.");
            Console.WriteLine("For Support Status, go to https://github.com/CSMarkBenchmark/CSMark/blob/master/Support.md");
                string benchAccuracy = "CM2";
                string newCommand = "";
                string timedStress = "";
                string stressTime = "";
                string stressConfirm = "";
            string choseTimed = "";
            string threads = "proc";
            int threadsD = 0;
            int threadDIteration = 2;

            while (true){
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("                                                                        ");
                    Console.Write("To run the single threaded and multi threaded tests, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("0");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the single threaded tests only, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the multi threaded tests only, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("2");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("To run the stress test utility, please enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("3");
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run test using a specified amount of threads enter the benchmark command followed by");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" _threads");
                Console.Write("To run the Extreme benchmark (Experimental) please enter 0, 1, or 2 followed by");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" X");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To force results to be saved immediately after running the benchmark, enter the benchmark command followed by");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" _save");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("To run the test with a specific amount of calculations, please enter");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" _calc");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Please give feedback, or report bugs by opening a GitHub issue at https://github.com/CSMarkBenchmark/CSMark/issues/new ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                if (benchCommand == null){
                    newCommand = Console.ReadLine().ToLower();
                }
                else if (benchCommand != null){
                    newCommand = benchCommand;
                }
                else{
                    newCommand = Console.ReadLine().ToLower();
                }
                    if (newCommand == "3" || newCommand == "stress" || newCommand == "stress_test"){
                    Console.WriteLine("Do you want to run a timed Stress Test?");
                    Console.WriteLine("Please enter Y or N");
                   choseTimed = Console.ReadLine().ToLower();

                   if(choseTimed == "y"){
                        Console.WriteLine("Select the time format in SECONDS, MINUTES or HOURS.");
                        timedStress = Console.ReadLine().ToLower();
                        Console.WriteLine("How many " + timedStress + " would you like the stress test to run for?");
                        stressTime = Console.ReadLine().ToLower();
                        Console.WriteLine("Are you sure you want to run the stress test for " + stressTime + " " + timedStress + "?");
                        Console.WriteLine("Please enter Y or N");

                        if(benchCommand == null){
                            stressConfirm = Console.ReadLine().ToLower();
                        }
                        else if(benchCommand != null){

                        }
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
                        else{
                            //Do nothing, the program will "continue" if the user doesn't say yes.
                        }
                        continue;
                    }
                   else if(choseTimed == "n"){
                        Console.WriteLine("To terminate the stress test enter BREAK or STOP.");
                        commandProcessor.startStressTest();
                        Console.WriteLine("Starting stress test.");
                        Console.WriteLine("To stop the stress test, please exit the program or enter STOP or BREAK");
                        newCommand = Console.ReadLine().ToLower();
                        if (newCommand == "break" || newCommand == "stop"){
                            commandProcessor.stopStressTest();
                        }
                        else{
                            commandProcessor.stopStressTest();
                        }
                        continue;
                        }                    
                    }
                    else if (newCommand.Contains("0") || newCommand.Contains("1") || newCommand.Contains("2") || newCommand.Contains("bench")){

                    if (!newCommand.Contains("_calc")){
                        Console.WriteLine("Please enter an accuracy level.");
                        Console.WriteLine("Accepted Accuracy Levels are CM1-CM5, PX1-PX5 and WX1-WX12");
                        Console.WriteLine("For more information on accuracy levels, go to: ");
                        Console.WriteLine("https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/AccuracyLevels.md");
                    }
                    else if(newCommand.Contains("_calc")){
                        Console.WriteLine("Please enter the amount of calculations you'd like to be performed in millions:");
                        try {
                            commandProcessor.setMaxIterations(double.Parse(Console.ReadLine()) * 1000 * 1000);
                        }
                        catch{
                            Console.WriteLine("Failed to set the custom amount of calculations.");
                        }
                    }

                    if (benchCommand == null && !newCommand.Contains("_calc")){
                        benchAccuracy = Console.ReadLine().ToUpper();
                        commandProcessor.setMaxIterations(benchAccuracy);
                    }
                    else if (benchCommand != null && !newCommand.Contains("_calc")){
                        commandProcessor.setMaxIterations(accuracyLevel);
                    }

                    if (newCommand.Contains("_threads")){
                        Console.WriteLine("How many threads would you like to complete the benchmark?");
                        Console.WriteLine("If you would like to run all from 1 to the total amount on your CPU. Please enter SYSTEM.");
                      
                        if(benchCommand == null){
                            threads = Console.ReadLine().ToLower();
                        }
                        else{
                            threads = threadsArg;
                        }

                        if (threads == "system"){
                            threadsD = Environment.ProcessorCount;
                        }
                        else{
                            threadsD = int.Parse(threads);
                        }
                    }

                    Console.WriteLine("Starting Tests...");
                    if (newCommand.Contains("bench") & newCommand.Contains("_extreme") || newCommand.Contains("0") & newCommand.Contains("X")){
                        commandProcessor.startBenchmarkExtreme(Environment.ProcessorCount);
                        commandProcessor.showExtremeResultsConsole(true, true);
                    }
                    else if (newCommand.Contains("bench_single") & newCommand.Contains("_extreme") || newCommand.Contains("1") & newCommand.Contains("X")){
                        commandProcessor.startBenchmarkExtreme_Single();
                        commandProcessor.showExtremeResultsConsole(true, false);
                    }
                    else if (newCommand.Contains("bench_multi") & newCommand.Contains("_extreme") || newCommand.Contains("2") & newCommand.Contains("X")){
                        commandProcessor.startBenchmarkExtreme_Multi(Environment.ProcessorCount);
                        commandProcessor.showExtremeResultsConsole(false, true);
                    }
                    else if (newCommand.Contains("bench_multi") & newCommand.Contains("_threads") || newCommand.Contains("2") & newCommand.Contains("_threads"))
                    {                                          
                        while (threadDIteration <= threadsD){
                            commandProcessor.startBenchmarkNormal_Multi(threadDIteration);
                            commandProcessor.showNormalResultsConsole(false, true);
                            threadDIteration++;
                        }
                    }
                    else if (newCommand.Contains("bench") & newCommand.Contains("_threads") || newCommand.Contains("0") & newCommand.Contains("_threads")){
                        commandProcessor.startBenchmarkNormal_Single();
                        commandProcessor.showNormalResultsConsole(true, true);
                        while (threadDIteration <= threadsD){
                            commandProcessor.startBenchmarkNormal_Multi(threadDIteration);
                            commandProcessor.showNormalResultsConsole(true, true);
                            threadDIteration++;
                        }
                    }
                    else if (newCommand.Contains("bench_single") || newCommand.Contains("1")){
                            commandProcessor.startBenchmarkNormal_Single();
                        commandProcessor.showNormalResultsConsole(true,false);
                         }
                  else if (newCommand.Contains("bench_multi") ||  newCommand == "bench-multi" || newCommand.Contains("2")){
                            commandProcessor.startBenchmarkNormal_Multi(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(false, true);
                         }
                   else if (newCommand.Contains("bench") || newCommand.Contains("0")){
                            commandProcessor.startBenchmarkNormal(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(true, true);
                        }    
                    else{
                        //Make CM2 the default accuracy level.
                        commandProcessor.setMaxIterations("CM2");
                            commandProcessor.startBenchmarkNormal(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(true, true);
                        }

                    if (newCommand.Contains("_save") || saveToFile == true){
                        commandProcessor.handleSaveDialog("y", CSMarkVersion);
                    }
                    else{
                        string save = "";
                        if (benchCommand == null){
                            Console.WriteLine("                                                ");
                            Console.WriteLine("Would you like to save the results to a Text File?");
                            Console.WriteLine("Please enter Y or N.");
                            save = Console.ReadLine().ToLower();
                        }                
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
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("CSMark Version: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(info.returnCSMarkVersionString());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("CSMark RID: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(new CSMarkPlatform().returnRID());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("CSMarkLib Version: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(new AboutLib().returnCSMarkLibVersionString());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("AutoUpdaterNetStandard Version: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(new AutoUpdaterNetStandard.AboutLib().returnVersionString());          
                    csM.getPlatform();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("OS ID: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(RuntimeInformation.OSDescription);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("OS Architecture: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(csM.returnOSArch());
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                    else if (newCommand == "clear" || newCommand == "restart" || newCommand == "clean"){
                        Console.Clear();
                        continue;
                    }
                    else if(newCommand == "help" || newCommand == "commands" || newCommand == "list_commands" || newCommand == "list_cmd" || newCommand == "halp"){
                    Console.WriteLine("List of supported commands: ");
                    Console.WriteLine("0");
                    Console.WriteLine("1");
                    Console.WriteLine("2");
                    Console.WriteLine("3");
                    Console.WriteLine("clear");
                    Console.WriteLine("about");
                    Console.WriteLine("exit");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("For more information on what these commands do, please go to: ");
                    Console.WriteLine("https://github.com/CSMarkBenchmark/CSMark/blob/master/docs/Commands.md");
                }
                    else{
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That's not a command supported by CSMark! Please enter a supported command.");
                        continue;
                    }

                if(exitOnComplete == true){
                    break;
                     }
                }
            }
        }
    }