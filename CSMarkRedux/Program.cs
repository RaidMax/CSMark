/* CSMark Copyright (C) 2017  AluminiumTech */
using CSMarkLib;
using CSMarkLib.BenchmarkManagement;
using CSMarkRedux.locales;
using System;
using System.Runtime.InteropServices;
namespace CSMarkRedux{
    class Program{
        public static string benchCommandArg;
        public static string accuracyLevel;
        public static bool saveToFile;
        public static bool exitOnComplete = false;
        public static string threadsArg;

        static void Main(string[] args){
            ///
            ///Accept command line arguments
            ///
            if (args.Length == 2){
                benchCommandArg = args[0];
                accuracyLevel = args[1];
            }
            else if(args.Length == 3){
                benchCommandArg = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
            }
            else if (args.Length == 4){
                benchCommandArg = args[0];
                accuracyLevel = args[1];
                saveToFile = bool.Parse(args[2]);
                exitOnComplete = bool.Parse(args[3]);
            }
            else if (args.Length == 5){
                benchCommandArg = args[0];
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
            LocaleManagement locales = new LocaleManagement();
            locales.checkLocale();
            string locale = locales.returnLocale();
            string CSMarkVersion = info.returnCSMarkVersionString() + "_";

            if (locale == "EN"){
                Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() +  " " + locale_EN.title_CommunityEdition;
                CSMarkVersion = CSMarkVersion + locale_EN._Edition;
            }         

          

            CommandProcessor commandProcessor = new CommandProcessor();
            info.showLicenseInfo();
            info.checkForUpdate();

            if(locale == "EN"){
                Console.WriteLine(locale_EN.title_Welcome);
                Console.WriteLine(locale_EN.title_Support);
            }
            //int langID;

            string exitCommand = "";
            string aboutCommand = "";
            string benchCommand = "";
            string calcCommand = "";
            string stressCommand = "";
            string benchSingleCommand = "";
            string benchMultiCommand = "";
            string benchExtremeCommand = "";
            string saveCommand = "";
            string clearCommand = "";
            string helpCommand = "";
            string respondYes = "";
            string respondNo = "";
            string respondSeconds = "";
            string respondMinutes = "";
            string respondHours = "";
            string respondStop = "";
            string respondBreak = "";
            string benchThreadsCommand = "";
            string respondSystem = "";
            string versionCommand = "";

            if(locales.returnLocale() == "EN"){
               exitCommand = locale_EN.commandExit;
                aboutCommand = locale_EN.commandAbout;
                calcCommand = locale_EN.commandCalc;
                clearCommand = locale_EN.commandClear;
                helpCommand = locale_EN.commandHelp;
                saveCommand = locale_EN.command_Save;
                stressCommand = locale_EN.command_Number3;
                benchCommand = locale_EN.command_Number0;
                benchSingleCommand = locale_EN.command_Number1;
                benchMultiCommand = locale_EN.command_Number2;
                respondYes = locale_EN.responseYes;
                respondNo = locale_EN.responseNo;
                respondSeconds = locale_EN.respondSeconds;
                respondMinutes = locale_EN.respondMinutes;
                respondHours = locale_EN.respondHours;
                respondStop = locale_EN.stressTest_Stop;
                respondBreak = locale_EN.stressTest_Break;
                benchExtremeCommand = locale_EN.command_Extreme;
                benchThreadsCommand = locale_EN.command_Threads;
                respondSystem = locale_EN.respondSystem;
                versionCommand = locale_EN.commandVersion;
            }

                string benchAccuracy = "Auto";
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
                if(locales.returnLocale() == "EN"){
                    Console.WriteLine(locale_EN.command_runNormal);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_runSingle);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number1);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_runMulti);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number2);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_runStress);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_runThreads);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Threads);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_runExtreme);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Extreme);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_ForceSave);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Save);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_Feedback + " " + locale_EN.commandsExtraInfo_URL);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (benchCommandArg == null){
                    newCommand = Console.ReadLine().ToLower();
                }
                else if (benchCommandArg != null){
                    newCommand = benchCommandArg;
                }
                else{
                    newCommand = Console.ReadLine().ToLower();
                }
                    if (newCommand == stressCommand || newCommand == "stress" || newCommand == "stress_test"){
                   if(locales.returnLocale() == "EN"){
                        Console.WriteLine(locale_EN.timedStressTest);
                        Console.WriteLine(locale_EN.responseYorN);
                    }
                   choseTimed = Console.ReadLine().ToLower();

                   if(choseTimed == respondYes){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.selectTimeFormat);
                        }
                        timedStress = Console.ReadLine().ToLower();

                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.timeFormat_HowMany + " " + stressTime + " " + locale_EN.timeFormat_Time);
                            stressTime = Console.ReadLine().ToLower();
                            Console.WriteLine(locale_EN.stressTestConfirm + " " + stressTime + " " + timedStress + "?");
                            Console.WriteLine(locale_EN.responseYorN);
                        }

                        if(benchCommandArg == null){
                            stressConfirm = Console.ReadLine().ToLower();
                        }
                        else if(benchCommandArg != null){

                        }
                        if (stressConfirm == respondYes){
                            if (timedStress == respondSeconds){
                                commandProcessor.startStressTest_Seconds(Double.Parse(stressTime));
                            }
                            else if (timedStress == respondMinutes){
                                commandProcessor.startStressTest_Minutes(Double.Parse(stressTime));
                            }
                            else if (timedStress == respondHours){
                                commandProcessor.startStressTest_Hours(Double.Parse(stressTime));
                            }
                        }
                        else{
                            //Do nothing, the program will "continue" if the user doesn't say yes.
                        }
                        continue;
                    }
                   else if(choseTimed == respondNo){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.stressTest_Start);
                            Console.WriteLine(locale_EN.stressTest_StopMessage);
                        }
                        commandProcessor.startStressTest();
                        newCommand = Console.ReadLine().ToLower();
                        if (newCommand == respondBreak || newCommand == respondStop){
                            commandProcessor.stopStressTest();
                        }
                        else{
                            commandProcessor.stopStressTest();
                        }
                        continue;
                        }                    
                    }
                    else if (newCommand.Contains(benchCommand) || newCommand.Contains(benchSingleCommand) || newCommand.Contains(benchMultiCommand)){  
                    if (!newCommand.Contains(calcCommand)){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.accuracyLevel);
                            Console.WriteLine(locale_EN.acceptedAccuracyLevel);
                            Console.WriteLine(locale_EN.accuracyInfo);
                            Console.WriteLine(locale_EN.accuracyInfoURL);
                        }
                    }
                    else if(newCommand.Contains(calcCommand)){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.calculations);
                        }
                        try {
                            commandProcessor.setMaxIterations(double.Parse(Console.ReadLine()) * 1000 * 1000);
                        }
                        catch{
                            if(locales.returnLocale() == "EN"){
                                Console.WriteLine(locale_EN.calculations_Failed);
                            }
                        }
                    }
                    if (benchCommand == null && !newCommand.Contains(calcCommand)){
                        benchAccuracy = Console.ReadLine().ToUpper();
                        commandProcessor.setMaxIterations(benchAccuracy);
                    }
                    else if (benchCommand != null && !newCommand.Contains(calcCommand)){
                        commandProcessor.setMaxIterations(accuracyLevel);
                    }
                    if (newCommand.Contains(benchThreadsCommand)){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.threads_HowMany);
                            Console.WriteLine(locale_EN.threads_All);
                        }
                      
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

                    if(locales.returnLocale() == "EN"){
                        Console.WriteLine(locale_EN.test_Starting);
                    }
                    if (newCommand.Contains(benchCommand) & newCommand.Contains(benchExtremeCommand)){
                        commandProcessor.startBenchmarkExtreme(Environment.ProcessorCount);
                        commandProcessor.showExtremeResultsConsole(true, true);
                    }
                    else if (newCommand.Contains(benchSingleCommand) & newCommand.Contains(benchExtremeCommand)){
                        commandProcessor.startBenchmarkExtreme_Single();
                        commandProcessor.showExtremeResultsConsole(true, false);
                    }
                    else if (newCommand.Contains(benchMultiCommand) & newCommand.Contains(benchExtremeCommand)){
                        commandProcessor.startBenchmarkExtreme_Multi(Environment.ProcessorCount);
                        commandProcessor.showExtremeResultsConsole(false, true);
                    }
                    else if (newCommand.Contains(benchMultiCommand) & newCommand.Contains(benchThreadsCommand))
                    {                                          
                        while (threadDIteration <= threadsD){
                            commandProcessor.startBenchmarkNormal_Multi(threadDIteration);
                            commandProcessor.showNormalResultsConsole(false, true);
                            threadDIteration++;
                        }
                    }
                    else if (newCommand.Contains(benchCommand) & newCommand.Contains(benchThreadsCommand)){
                        commandProcessor.startBenchmarkNormal_Single();
                        commandProcessor.showNormalResultsConsole(true, true);
                        while (threadDIteration <= threadsD){
                            commandProcessor.startBenchmarkNormal_Multi(threadDIteration);
                            commandProcessor.showNormalResultsConsole(true, true);
                            threadDIteration++;
                        }
                    }
                    else if (newCommand.Contains(benchSingleCommand)){
                            commandProcessor.startBenchmarkNormal_Single();
                        commandProcessor.showNormalResultsConsole(true,false);
                         }
                  else if (newCommand.Contains(benchMultiCommand)){
                            commandProcessor.startBenchmarkNormal_Multi(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(false, true);
                         }
                   else if (newCommand.Contains(benchCommand)){
                            commandProcessor.startBenchmarkNormal(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(true, true);
                        }    
                    else{
                        //Make CM2 the default accuracy level.
                        commandProcessor.setMaxIterations("CM2");
                            commandProcessor.startBenchmarkNormal(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(true, true);
                        }

                    if (newCommand.Contains(saveCommand) || saveToFile == true){
                        if (locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.save_ReminderInstall);
                        }
                            try{
                            commandProcessor.handleSaveDialog("y", CSMarkVersion);
                        }
                        catch{
                            Console.WriteLine(locale_EN.save_Fail);
                        }
                    }
                    else{
                        string save = "";
                        if (benchCommand == null){
                            Console.WriteLine("                                                ");
                            if(locales.returnLocale() == "EN"){
                                Console.WriteLine(locale_EN.save_ReminderInstall);
                                Console.WriteLine(locale_EN.confirmSave);
                                Console.WriteLine(locale_EN.responseYorN);
                            }
                            save = Console.ReadLine().ToLower();
                        }                
                        commandProcessor.handleSaveDialog(save, CSMarkVersion);
                        continue;
                        }              
                    }
                    else if (newCommand == exitCommand){
                        break;
                    }
                    else if(newCommand == aboutCommand || newCommand == versionCommand){
                    Console.WriteLine("                                     ");
                    Console.WriteLine("                                     ");

                    if (locales.returnLocale() == "EN"){
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkVersion);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(info.returnCSMarkVersionString());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkRID);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new CSMarkPlatform().returnRID());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.csmarkLibVersion);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new AboutLib().returnCSMarkLibVersionString());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.autoUpdaterNetStandardVersion);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(new AutoUpdaterNetStandard.AboutLib().returnVersionString());
                        csM.getPlatform();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.osID);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(RuntimeInformation.OSDescription);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(locale_EN.archID);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(csM.returnOSArch());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                           
                }
                    else if (newCommand == clearCommand){
                        Console.Clear();
                        continue;
                    }
                    else if(newCommand == helpCommand){
                    if(locales.returnLocale() == "EN"){
                        Console.WriteLine(locale_EN.commands_SupportedInfo);
                        Console.WriteLine(locale_EN.command_Number0);
                        Console.WriteLine(locale_EN.command_Number1);
                        Console.WriteLine(locale_EN.command_Number2);
                        Console.WriteLine(locale_EN.command_Number3);
                        Console.WriteLine(locale_EN.commandClear);
                        Console.WriteLine(locale_EN.commandAbout);
                        Console.WriteLine(locale_EN.commandExit);
                        Console.WriteLine("                                        ");
                        Console.WriteLine(locale_EN.commandsExtraInfo);
                        Console.WriteLine(locale_EN.commandsExtraInfo_URL);
                    }
                }
                    else{
                        Console.ForegroundColor = ConsoleColor.Red;
                    if(locales.returnLocale() == "EN"){
                        Console.WriteLine(locale_EN.commandNotSupported);
                    }
                        continue;
                    }

                if(exitOnComplete == true){
                    break;
                     }
                }
            }
        }
    }