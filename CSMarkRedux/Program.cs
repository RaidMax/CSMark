/* CSMark Copyright (C) 2017  AluminiumTech */
using CSMarkLib;
using CSMarkLib.BenchmarkManagement;
using CSMarkRedux.locales;
using System;
using System.Runtime.InteropServices;
namespace CSMarkRedux{
    class Program{
        public static string benchCommandArg = "";
        public static string accuracyLevel = "";
        public static bool saveToFile = false;
        public static string threadsArg = "";

        static void Main(string[] args) {     
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
                threadsArg = args[3];
            }

            CSMarkPlatform csM = new CSMarkPlatform();
            Information info = new Information();
            LocaleManagement locales = new LocaleManagement();

            locales.checkLocale();
            string locale = locales.returnLocale();
            string CSMarkVersion = info.returnCSMarkVersionString() + "_";
            CommandProcessor commandProcessor = new CommandProcessor();
            info.showLicenseInfo();
            info.checkForUpdate(locale);
            
            //int langID;

            string exitCommand = "";
            string aboutCommand = "";
            string benchCommand = "";
            string calcCommand = "";
            string stressCommand = "";
            string benchSingleCommand = "";
            string benchMultiCommand = "";
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
               exitCommand = locale_EN.commandExit.ToLower();
                aboutCommand = locale_EN.commandAbout.ToLower();
                calcCommand = locale_EN.commandCalc.ToLower();
                clearCommand = locale_EN.commandClear.ToLower();
                helpCommand = locale_EN.commandHelp.ToLower();
                saveCommand = locale_EN.command_Save.ToLower();
                stressCommand = locale_EN.command_Number3;
                benchCommand = locale_EN.command_Number0;
                benchSingleCommand = locale_EN.command_Number1;
                benchMultiCommand = locale_EN.command_Number2;
                respondYes = locale_EN.responseYes.ToLower();
                respondNo = locale_EN.responseNo.ToLower();
                respondSeconds = locale_EN.respondSeconds.ToLower();
                respondMinutes = locale_EN.respondMinutes.ToLower();
                respondHours = locale_EN.respondHours.ToLower();
                respondStop = locale_EN.stressTest_Stop.ToLower();
                respondBreak = locale_EN.stressTest_Break.ToLower();
                benchThreadsCommand = locale_EN.command_Threads.ToLower();
                respondSystem = locale_EN.respondSystem.ToLower();
                versionCommand = locale_EN.commandVersion.ToLower();
            }

              string benchAccuracy = "Auto";
                string newCommand = "";
                string timedStress = "";
                string stressTime = "";
                string stressConfirm = "";
            string choseTimed = "";
        //    string threads = "system";
            int threadsD = 0;
            int threadDIteration = 2;

            if (locale == "EN"){
                Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_CommunityEdition;
                CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                Console.WriteLine(locale_EN.title_Welcome);
                Console.WriteLine(locale_EN.title_Support);
            }
            else{
                locales.checkLocale();

                if(locales.returnLocale() != locale){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Locale Detection took a long time to respond. Applying correct Locales.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if(locales.returnLocale() == "EN"){
                        Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_CommunityEdition;
                        CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                        Console.WriteLine(locale_EN.title_Welcome);
                        Console.WriteLine(locale_EN.title_Support);
                    }
                }
                else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Locale Detection didn't respond in time. Falling back to English as default.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Title = locale_EN.title_Name + " " + info.returnCSMarkVersionString() + " " + locale_EN.title_CommunityEdition;
                    CSMarkVersion = CSMarkVersion + locale_EN._Edition;
                    Console.WriteLine(locale_EN.title_Welcome);
                    Console.WriteLine(locale_EN.title_Support);
                }              

            }

            while (true){
                Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("                                                                        ");
                if(locales.returnLocale() == "EN"){
                    Console.Write(locale_EN.command_runNormal + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number0);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runSingle + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number1);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runMulti + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number2);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runStress + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Number3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_runThreads + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Threads);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(locale_EN.command_ForceSave + " ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(locale_EN.command_Save);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(locale_EN.command_Feedback);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                    newCommand = Console.ReadLine().ToLower();
                

                    if (newCommand == stressCommand){
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
                          benchAccuracy =  Console.ReadLine();

                            if(benchAccuracy == "") {
                                commandProcessor.setAutoMaxIterations();
                            }
                            else{
                                commandProcessor.setMaxIterations(benchAccuracy);
                            }
                           
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
                    if (newCommand.Contains(benchThreadsCommand)){
                        if(locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.threads_HowMany);
                            Console.WriteLine(locale_EN.threads_All);
                        }
                       
                    }

                    if(locales.returnLocale() == "EN"){
                        Console.WriteLine(locale_EN.test_Starting);
                    }

                    if (newCommand.Contains(benchMultiCommand) && newCommand.Contains(benchThreadsCommand))
                    {                                          
                        while (threadDIteration <= threadsD){
                            commandProcessor.startBenchmarkNormal_Multi(threadDIteration);
                            commandProcessor.showNormalResultsConsole(false, true);
                            threadDIteration++;
                        }
                    }
                    else if (newCommand.Contains(benchCommand) && newCommand.Contains(benchThreadsCommand)){
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
                        //Make AUTO the default accuracy level.
                        commandProcessor.setMaxIterations("Auto");
                            commandProcessor.startBenchmarkNormal(Environment.ProcessorCount);
                        commandProcessor.showNormalResultsConsole(true, true);
                        }

                    if (newCommand.Contains(saveCommand)){
                        if (locales.returnLocale() == "EN"){
                            Console.WriteLine(locale_EN.save_ReminderInstall);
                        }
                        try{
                            commandProcessor.handleSaveDialog_Normal(CSMarkVersion);
                        }
                        catch{
                            Console.WriteLine(locale_EN.save_Fail);
                        }
                    }
                    else{
                        string save = "";
                            Console.WriteLine("                                                ");
                            if(locales.returnLocale() == "EN"){
                            
                            ///We don't need to show this message to mac or linux users
                            if (new CSMarkPlatform().returnOSPlatform().Contains("win")){
                                Console.WriteLine(locale_EN.save_ReminderInstall);
                            }                  
                                Console.WriteLine(locale_EN.confirmSave);
                                Console.WriteLine(locale_EN.responseYorN);   
                        }
                        save = Console.ReadLine().ToLower();

                            if(save.ToLower() == "yes"){
                                commandProcessor.handleSaveDialog_Normal(CSMarkVersion);
                            }
                        continue;
                        }              
                    }
                    else if (newCommand.ToLower() == exitCommand.ToLower()){
                        break;
                    }
                    else if(newCommand.ToLower() == aboutCommand.ToLower() || newCommand.ToLower() == versionCommand.ToLower()){
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
                    else if (newCommand.ToLower() == clearCommand.ToLower()){
                        Console.Clear();
                        continue;
                    }
                    else if(newCommand.ToLower() == helpCommand.ToLower()){
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
                }
            }
        }
      }